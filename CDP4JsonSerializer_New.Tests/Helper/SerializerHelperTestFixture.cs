// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerHelperTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer_New.Tests.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.MetaInfo;
    using CDP4Common.Types;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="SerializerHelper"/> class.
    /// </summary>
    [TestFixture]
    public class SerializerHelperTestFixture
    {
        [Test]
        public void VerifyThatToJsonObjectOfOrderedItemReturnsJObject()
        {
            var uniqueIdentifier = Guid.NewGuid();

            var orderedItem = new OrderedItem {K = 1, V = uniqueIdentifier};

            var propertyInfo = orderedItem.GetType().GetProperty("M");

            var value = System.Convert.ChangeType(123, Nullable.GetUnderlyingType(propertyInfo.PropertyType));
            propertyInfo.SetValue(orderedItem, value);

            var jObject = orderedItem.ToJsonObject();
            Assert.AreEqual(3, jObject.Properties().Count());

            var k = jObject.Property("k");
            Assert.IsNotNull(k);            

            var v = jObject.Property("v");
            Assert.IsNotNull(v);

            var m = jObject.Property("m");
            Assert.IsNotNull(m);
        }

        [Test]
        public void Verify_that_ParameterValueSet_is_serialized_and_deserialized()
        {
            var values = new List<string>();
            values.Add("this is a\nnewline");
            values.Add("this is another\nnewline");

            var engineeringModel = new EngineeringModel { Iid = Guid.Parse("5643764e-f880-44bf-90ae-361f6661ceae") };
            var iteration = new Iteration { Iid = Guid.Parse("f744ae63-cf36-4cc4-8d76-e83edd44f6d2") };
            var elementDefinition = new ElementDefinition { Iid = Guid.Parse("f7f173ea-a742-42a5-81f1-59da2f470f16") };
            var parameter = new Parameter { Iid = Guid.Parse("607764de-7598-4be2-9a95-34669de273e3") };
            var parameterValueSet = new ParameterValueSet
            {
                Iid = Guid.Parse("2366c662-b857-4313-85ea-51f9bf4588b1"),
                Manual = new ValueArray<string>(values)
            };

            engineeringModel.Iteration.Add(iteration);
            iteration.Element.Add(elementDefinition);
            elementDefinition.Parameter.Add(parameter);
            parameter.ValueSet.Add(parameterValueSet);

            var metadataprovider = new MetaDataProvider();
            var serializer = new CDP4JsonSerializer(metadataprovider, new Version(1, 1, 0));

            var result = serializer.SerializeToString(parameterValueSet, false);

            var stream = StreamHelper.GenerateStreamFromString(result);
            var dtos = serializer.Deserialize(stream);
            var dto = dtos.Single() as CDP4Common.DTO.ParameterValueSet;

            Assert.That(dto.Manual, Is.EquivalentTo(values));
        }

        [Test]
        public void Verify_that_a_ValueArray_is_serialized_and_deserialized([ValueSource(nameof(TestStrings))] string input)
        {
            var valueArray = new ValueArray<string>(new List<string> { input });
            var json = valueArray.ToJsonString();
            var result = SerializerHelper.ToValueArray<string>(json);

            Assert.AreEqual(valueArray, result, "ValueArray creation failed for string \"{0}\"", input);

            var resultjson = result.ToJsonString();

            Assert.AreEqual(json, resultjson, "Json creation failed for string \"{0}\"", input);
        }
        
        private const string JsonString = @"{""widget"": {
                ""debug"": ""on"",
                ""window"": {
                    ""title"": ""Sample Konfabulator Widget"",
                    ""name"": ""main_window"",
                    ""width"": 500,
                    ""height"": 500
                },
                ""image"": { 
                    ""src"": ""Images/Sun.png"",
                    ""name"": ""sun1"",
                    ""hOffset"": 250,
                    ""vOffset"": 250,
                    ""alignment"": ""center""
                },
                ""text"": {
                    ""data"": ""Click Here"",
                    ""size"": 36,
                    ""style"": ""bold"",
                    ""name"": ""text1"",
                    ""hOffset"": 250,
                    ""vOffset"": 100,
                    ""alignment"": ""center"",
                    ""onMouseUp"": ""sun1.opacity = (sun1.opacity / 100) * 90;""
                }
            }}";

        private const string XmlString = @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <bookstore>
                <book category=""cooking"">
                    <title lang=""en"">Everyday food</title>
                    <author>Some great cook</author>
                    <year>2005</year>
                    <price>30.00</price>
                    <data><![CDATA[Within this Character Data block I can
                        use double dashes as much as I want (along with <, &, ', and "")
                        *and* %MyParamEntity; will be expanded to the text
                        ""Has been expanded"" ... however, I can't use
                        the CEND sequence.If I need to use CEND I must escape one of the
                        brackets or the greater-than sign using concatenated CDATA sections.
                        ]]></data>
                </book>
                <book category=""children"">
                    <title lang=""en"">Harry the child</title>
                    <author>Some child author</author>
                    <year>2005</year>
                    <price>29.99</price>
                </book>
                <book category=""web"">
                    <title lang=""en"">Learning XML</title>
                    <author>Some XML expert</author>
                    <year>2003</year>
                    <price>39.95</price>
                </book>
            </bookstore>";

        private static readonly string[] TestStrings = 
        {
            "value with trailing spaces  ",
            "value with trailing space ",
            " value with leading spaces",
            "  value with leading space",
            "\t\t\tvalue with leading and trailing tabs \t",
            "\nvalue with leading and trailing linebreaks \r",
            "=2*(2+2)",
            "=2*\n(2+2)",
            "=2*\r(2+2)",
            "=2*\r\n(2+2)",
            "=2*\n\r(2+2)",
            "= 2 * \n ( 2 + 2 )",
            "=2*\b(2+2)",
            "=2*\f(2+2)",
            "=2*\t(2+2)",
            "Ar54WbBu + yhw - R:G!d)C!X_H % Vy ? V",
            "qm+L/{hp,qU[F\nnSyFymmZ\n+F(G/pP8@",
            "JSfJzH!U5:*wcnzT+{a5-L&+Xaq[g4",
            "EfRKJ[*A%uiM9MJ_h-z?9X(KYJQ/xL",
            "B_Dw+Tw.7g,.36]7(j8(k3/hxX,K_y",
            "qKt_C}@).D!ik.4W48ESR}w*VGvaub",
            "33CDr2NPZ[fJQ]p?aXT2L{giUUm}g#",
            "mpb-!ump7S{D)]Z9B@S([FXMRSq/9S",
            "D,VeZQRnV/}?}*qxMeX}N7*%R]!Tf/",
            "L$X7@P,JhcYM,-e4Z5,!ft.UbC[Y{n",
            "QWuAr.P$RUCf(NiV{7}tcwnia:.Fnp",
            "L%%t?cdpa?g#-PE4w6=[yU72Cgxz:f",
            ",GCeVX=$6R,(JJW[mLd4uF@{,Yr%NL",
            "i?5,/.G%D,M3im?8:,+ju}(CMh_E77",
            "}8Bn)rtS4BGTWThmT,=nu,q{[H?):9",
            "ScVmbHjSB[HS$8A*C{awPvvp{%@5Xr",
            "wy6bDVDuim}YLhB24=[y6!4vpM2pTw",
            "f:][.LfcN#(gH=Dq$6Lcp7TWQP7LH!",
            "!&.v8L44$ep69u+W-_5jq?DV@fi($H",
            "?_uB5Z(U$B6,cVPMPJv%q}d[+2PAMZ",
            "[_*q5d$U{qE7}r_7$fdf$h5yBFpPG+",
            XmlString,
            JsonString
        };
    }
}