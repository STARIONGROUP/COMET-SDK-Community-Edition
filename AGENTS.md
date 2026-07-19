# AGENTS.md

This file provides guidance to Codex (Codex.ai/code) when working with code in this repository.

## Project Overview

The CDP4-COMET SDK is a C# SDK compliant with ECSS-E-TM-10-25A Annex A and Annex C, used for Concurrent Design of complex systems. It produces 12 NuGet packages (suffixed `-CE`) published to nuget.org. Licensed under GNU LGPL.

## Build Commands

```bash
# Restore, build, and test
dotnet restore CDP4-SDK.sln
dotnet build --no-restore CDP4-SDK.sln
dotnet test --no-build CDP4-SDK.sln --filter="(TestCategory!~WebServicesDependent) & (TestCategory!~CICDExclusion)"

# Run a single test project
dotnet test --no-build CDP4Common.NetCore.Tests/CDP4Common.NetCore.Tests.csproj

# Run a specific test by name
dotnet test --no-build CDP4-SDK.sln --filter="FullyQualifiedName~MyTestClass.MyTestMethod"

# Pack for release
dotnet pack -c Release -o ReleaseBuilds

# Version bump (all library csproj files)
bash versionBump.sh <new-version>
```

## Target Frameworks

- **Library projects**: `net48;netstandard2.0` (multi-targeted)
- **Test projects (`.Tests`)**: `net48` only
- **Test projects (`.NetCore.Tests`)**: `net10.0`

Both test variants exist to verify behavior on .NET Framework and modern .NET.

## Architecture

### DTO ↔ POCO ↔ Cache Pipeline

The central architectural pattern is the conversion pipeline between lightweight DTOs and full object-graph POCOs:

1. **DTOs** (`CDP4Common/AutoGenDto/`) — auto-generated, use GUIDs for references, decorated with `[DataContract]`/`[DataMember]`. Used for serialization and REST API communication.
2. **POCOs** (`CDP4Common/AutoGenPoco/`) — auto-generated, hold direct object references. Used throughout application code.
3. **PocoThingFactory** (`CDP4Common/Helpers/`) — converts DTOs to POCOs and resolves GUID references into object references.
4. **Assembler** (`CDP4Dal/Assembler.cs`) — maintains a concurrent cache (`ConcurrentDictionary<CacheKey, Lazy<Thing>>`), synchronizes DTOs into cached POCOs, manages deletions and unresolved references.
5. **Session** (`CDP4Dal/Session.cs`) — manages a connection to a data source, owns the Assembler, Credentials, PermissionService, and CDPMessageBus.

Data flow: External source → DTO → Assembler.Synchronize() → PocoThingFactory → POCO cache → MessageBus notifications

### Key Libraries

- **CDP4Common**: POCO/DTO classes, MetaInfo reflection system, custom collection types (ContainerList, OrderedItemList, CacheKey)
- **CDP4Dal**: Session, Assembler, CDPMessageBus (event-driven MVVM), DAL interface, PermissionService, OperationContainer
- **CDP4DalCommon**: Common protocol support classes
- **CDP4JsonSerializer / CDP4MessagePackSerializer**: Serialization of DTOs (Json.NET / MessagePack)
- **CDP4JsonFileDal**: ECSS-E-TM-10-25A Annex C.3 ZIP exchange file format implementation
- **CDP4ServicesDal**: ECSS-E-TM-10-25A Annex C.2 JSON REST API client (CDP4-COMET specific)
- **CDP4Web**: Helper classes for CDP4ServicesDal clients
- **CDP4Rules**: Rule-checking engine for validating POCOs beyond what the UML model enforces
- **CDP4RequirementsVerification**: Requirements verification against designs
- **CDP4Reporting**: Reporting support
- **CDP4ServicesMessaging**: RabbitMQ/AMQP messaging abstractions

### Auto-Generated Code

Many folders prefixed with `AutoGen` contain generated code from the CDP4-COMET UML master model. Key generated folders in CDP4Common:
- `AutoGenPoco/`, `AutoGenDto/`, `AutoGenMetaInfo/`, `AutoGenEquatable/`, `AutoGenSentinel/`, `AutoGenThingPropertyAccessor/`

Do not manually edit auto-generated files.

### DAL Plugin System

DAL implementations use MEF (Managed Extensibility Framework) via `DalExportAttribute` in `CDP4Dal/Composition/`.

## Test Framework

- **NUnit** (v4.x) with NUnit3TestAdapter
- **Moq** for mocking
- Test categories to be aware of: `WebServicesDependent` (requires running services), `CICDExclusion` (excluded from CI)

## Code Style

- 4-space indentation, no tabs
- No `_` prefix for member names; use `this.` for instance members
- Use `var` unless the inferred type is not obvious
- Use C# type aliases (`int`, `string`, not `Int32`, `String`)
- Always use curly braces for `if`/`else`/`using` blocks
- Place `using` statements inside the namespace
- No `#region` directives
- ReSharper settings available in `.DotSettings` file

## Git Workflow

- **master**: main/release branch
- **development**: integration branch (current default working branch)
- Feature branches are created from `development`
- PRs target `development`, not `master`

## Do's and Don'ts

- do not use python in this repository