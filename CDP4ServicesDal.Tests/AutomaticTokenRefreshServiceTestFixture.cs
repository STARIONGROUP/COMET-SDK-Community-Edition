// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AutomaticTokenRefreshServiceTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
// 
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4ServicesDal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CDP4Dal;
    using CDP4Dal.DAL;

    using CDP4DalCommon.Authentication;

    using Moq;

    using NUnit.Framework;

    using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

    [TestFixture]
    public class AutomaticTokenRefreshServiceTestFixture
    {
        private AuthenticationTokenRefreshService authenticationTokensRefreshService;
        private Mock<IProvideExternalAuthenticationService> openIdConnectService;
        private Mock<ISession> session;
        private Credentials credentials;
        
        [SetUp]
        public void Setup()
        {
            this.credentials = new Credentials(new Uri("http://localhost:5000/"));
            
            this.session = new Mock<ISession>();
            this.session.Setup(x => x.Credentials).Returns(this.credentials);
            
            this.openIdConnectService = new Mock<IProvideExternalAuthenticationService>();
            this.authenticationTokensRefreshService = new AuthenticationTokenRefreshService(this.openIdConnectService.Object);
        }

        [Test]
        public async Task VerifyAutomaticRefreshServiceBehavior()
        {
            await Assert.ThatAsync(() => this.authenticationTokensRefreshService.StartAsync(), Throws.InvalidOperationException);

            var dal = new Mock<IDal>();
            this.session.Setup(x => x.Dal).Returns(dal.Object);

            var authenticationSchemeResponse = new AuthenticationSchemeResponse()
            {
                    Schemes = [AuthenticationSchemeKind.Basic]
            };
            
            this.authenticationTokensRefreshService.Initialize(this.session.Object, authenticationSchemeResponse);
            
            var sw = Stopwatch.StartNew();
            await this.authenticationTokensRefreshService.StartAsync();
            Assert.That(sw.ElapsedMilliseconds, Is.LessThan(200));

            var cdpServicesDal = new Mock<IDal>();
            this.session.Setup(x => x.Dal).Returns(cdpServicesDal.Object);

            sw = Stopwatch.StartNew();
            await this.authenticationTokensRefreshService.StartAsync();
            Assert.That(sw.ElapsedMilliseconds, Is.LessThan(200));

            var issuedAtTime = DateTimeOffset.UtcNow;
            var accessExpirationTime = issuedAtTime.AddSeconds(20);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>()
            {
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
                new (JwtRegisteredClaimNames.Iat, issuedAtTime.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new (JwtRegisteredClaimNames.Exp, accessExpirationTime.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            };
            
            var jwtSecurityToken = new JwtSecurityToken(
                "http://localhost:5000/",
                "*",
                claims
            );
            
            this.session.Setup(x=> x.RequestAuthenticationTokenBasedOnRefreshToken()).Returns(Task.CompletedTask);
            this.credentials.ProvideUserToken(new AuthenticationToken(jwtSecurityTokenHandler.WriteToken(jwtSecurityToken), ""), AuthenticationSchemeKind.LocalJwtBearer);
            
            sw = Stopwatch.StartNew();
            await this.authenticationTokensRefreshService.StartAsync();
            Assert.That(sw.ElapsedMilliseconds, Is.LessThan(200));

            this.credentials.ProvideUserToken(new AuthenticationToken(jwtSecurityTokenHandler.WriteToken(jwtSecurityToken), "refresh"), AuthenticationSchemeKind.LocalJwtBearer);

            sw = Stopwatch.StartNew();
            await this.authenticationTokensRefreshService.StartAsync();
            
            Assert.Multiple(() =>
            {
                Assert.That(sw.ElapsedMilliseconds, Is.LessThan(20000));
                Assert.That(sw.ElapsedMilliseconds, Is.GreaterThan(16000));
            });
        }

        [Test]
        public async Task VerifyRefreshAuthenticationToken()
        {
            await Assert.ThatAsync(() => this.authenticationTokensRefreshService.RefreshAuthenticationInformationAsync(), Throws.InvalidOperationException.With.Message.EqualTo("This service is not initialized."));
            var authenticationSchemeResponse = new AuthenticationSchemeResponse();
            
            this.authenticationTokensRefreshService.Initialize(this.session.Object, authenticationSchemeResponse);
            await Assert.ThatAsync(() => this.authenticationTokensRefreshService.RefreshAuthenticationInformationAsync(), Throws.InvalidOperationException.With.Message.EqualTo("Related credentials does not contains any token."));

            this.session.Setup(x => x.RequestAuthenticationTokenBasedOnRefreshToken()).Returns(Task.CompletedTask);
            
            var authenticationTokens = new AuthenticationToken("access", "refresh");
            this.credentials.ProvideUserToken(authenticationTokens, AuthenticationSchemeKind.LocalJwtBearer);

            await this.authenticationTokensRefreshService.RefreshAuthenticationInformationAsync();
            this.session.Verify(x => x.RequestAuthenticationTokenBasedOnRefreshToken(), Times.Once);
            
            this.credentials.ProvideUserToken(authenticationTokens, AuthenticationSchemeKind.ExternalJwtBearer);

            var openIdAuthenticatioDto = new AuthenticationToken("new acceess", "new refresh");
            
            this.openIdConnectService.Setup(x => x.RequestAuthenticationToken(authenticationTokens.RefreshToken, authenticationSchemeResponse, null, null))
                .ReturnsAsync(openIdAuthenticatioDto);
            
            await this.authenticationTokensRefreshService.RefreshAuthenticationInformationAsync();
            Assert.That(this.credentials.Token, Is.EqualTo(openIdAuthenticatioDto));            
        }
    }
}
