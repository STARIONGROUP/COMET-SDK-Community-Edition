dotnet restore CDP4-SDK.sln
dotnet build --no-restore CDP4-SDK.sln
dotnet test --no-build CDP4-SDK.sln --filter="(TestCategory!~WebServicesDependent) & (TestCategory!~AppVeyorExclusion)"