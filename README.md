![CDP4-COMET](https://raw.githubusercontent.com/STARIONGROUP/COMET-SDK-Community-Edition/master/Comet_Logo.jpg)

The CDP4-COMET Software Development Kit is an C# SDK that that is compliant with ECSS-E-TM-10-25A Annex A and Annex C. The SDK contains multiple libraries that are each packaged as a nuget and avaialble from [nuget.org](https://www.nuget.org/packages?q=cdp4). The SDK is used in the CDP4-COMET to create an ECSS-E-TM-10-25A compliant implementation, for the [Web Services](https://github.com/STARIONGROUP/COMET-WebServices-Community-Edition), the [Desktop Application](https://github.com/STARIONGROUP/COMET-IME-Community-Edition) and the [Web-Application](https://github.com/STARIONGROUP/COMET-WEB-Community-Edition). The libraries are made avaiable in the Community Edition under the [GNU LGPL](https://www.gnu.org/licenses/lgpl-3.0.html):

## Nuget

The SDK contains multiple libraries that are each packaged as a nuget and avaialble from [nuget.org](https://www.nuget.org/packages?q=cdp4).

Package | Link
--------|--------
CDP4Common | ![NuGet Badge](https://img.shields.io/nuget/v/CDP4Common-CE)
CDP4Rules | ![NuGet Badge](https://img.shields.io/nuget/v/CDP4Rules-CE)
CDP4RequirementsVerification | ![NuGet Badge](https://img.shields.io/nuget/v/CDP4Rules-CE)
CDP4JsonSerializer | ![NuGet Badge](https://img.shields.io/nuget/v/CDP4JsonSerializer-CE)
CDP4MessagePackSerializer | ![NuGet Badge](https://img.shields.io/nuget/v/CDP4MessagePackSerializer-CE)
CDP4Reporting | ![NuGet Badge](https://img.shields.io/nuget/v/CDP4Reporting-CE)
CDP4Dal | ![NuGet Badge](https://img.shields.io/nuget/v/CDP4Dal-CE)
CDP4DalCommon | ![NuGet Badge](https://img.shields.io/nuget/v/CDP4DalCommon-CE)
CDP4JsonFileDal | ![NuGet Badge](https://img.shields.io/nuget/v/CDP4JsonFileDal-CE)
CDP4ServicesDal | ![NuGet Badge](https://img.shields.io/nuget/v/CDP4ServicesDal-CE)
CDP4Web | ![NuGet Badge](https://img.shields.io/nuget/v/CDP4Web-CE)
CDP4ServicesMessaging | ![NuGet Badge](https://img.shields.io/nuget/v/CDP4ServicesMessaging-CE)

## Build status

GitHub actions are used to build and test the libraries

Branch | Build Status
------- | :------------
Master | ![Build Status](https://github.com/STARIONGROUP/COMET-SDK-Community-Edition/actions/workflows/CodeQuality.yml/badge.svg?branch=master)
Development | ![Build Status](https://github.com/STARIONGROUP/COMET-SDK-Community-Edition/actions/workflows/CodeQuality.yml/badge.svg?branch=development)

## SonarQube Status:
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_CDP4-SDK-Community-Edition&metric=alert_status)](https://sonarcloud.io/dashboard?id=STARIONGROUP_CDP4-SDK-Community-Edition)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_CDP4-SDK-Community-Edition&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=STARIONGROUP_CDP4-SDK-Community-Edition)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_CDP4-SDK-Community-Edition&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=STARIONGROUP_CDP4-SDK-Community-Edition)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_CDP4-SDK-Community-Edition&metric=security_rating)](https://sonarcloud.io/dashboard?id=STARIONGROUP_CDP4-SDK-Community-Edition)

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_CDP4-SDK-Community-Edition&metric=coverage)](https://sonarcloud.io/dashboard?id=STARIONGROUP_CDP4-SDK-Community-Edition)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_CDP4-SDK-Community-Edition&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=STARIONGROUP_CDP4-SDK-Community-Edition)

[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_CDP4-SDK-Community-Edition&metric=bugs)](https://sonarcloud.io/dashboard?id=STARIONGROUP_CDP4-SDK-Community-Edition)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_CDP4-SDK-Community-Edition&metric=ncloc)](https://sonarcloud.io/dashboard?id=STARIONGROUP_CDP4-SDK-Community-Edition)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_CDP4-SDK-Community-Edition&metric=sqale_index)](https://sonarcloud.io/dashboard?id=STARIONGROUP_CDP4-SDK-Community-Edition)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=STARIONGROUP_CDP4-SDK-Community-Edition&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=STARIONGROUP_CDP4-SDK-Community-Edition)

## CDP4Common

The CDP4Common library is a C# implementation of the CDP4-COMET UML master model. The CDP4-COMET UML master model is based on the ECSS-E-TM-10-25A Annex A UML master model and extends it with CDP4-COMET concepts to improve the use of ECSS-E-TM-10-25A Annex A for Concurrent Design of complex systems. The library contains both POCO and DTO implementations of the classes defined in the CDP4-COMET UML master model. The POCO classes are used when a full object graph is required. The DTO's are used when a full object graph is not required, references to other class are represented by unique identifiers in the form of a GUID.

The CDP4Common library also includes a set of so-called MetaInfo classes. These classes are used to provide information about the classes in the UML master model such as the properties, relationships to other classes etc. These classes provide similar functionality as the C# reflection system, but with higher performance.

## CDP4Rules

The CDP4Rules library provides a mechanism for checking CDP4-COMET instances versus defined **rules**. This rule checking mechanism is introduced to verify the correctness of POCO's that cannot be verified based on the CDP4-COMET Master (UML) model (such as multiplicity, type information, etc.). Each rule has a code, description and default severity.

## CDP4RequirementsVerification

The CDP4RequirementsVerification library is used to perform requirements verification. E-TM-10-25 contains concepts to make record of requirements and to verify whether a design meets those requirements.

## CDP4JsonSerializer

The CDP4JsonSerializer library is an optimized CDP4Common specific JSON (de)serialization library that is used to serialize and deserialize the classes implemented in the CDP4Common class library. The (de)serialization makes use of the popular Json.NET framework to serialize and deserialize the CDP4Common DTO classes.

## CDP4MessagePackSerializer

The CDP4MessagePackSerializer library is an optimized CDP4Common specific MessagePack (de)serialization library that is used to serialize and deserialize the classes implemented in the CDP4Common class library.

## CDP4Dal

The CDP4Dal library is a library that provides the basis to implement ECSS-E-TM-10-25A Annex C. Annex C specifies both the JSON REST API and the exchange file format. The CDP4Dal library contains the Assembler that is used to create a fully dereferenced object graph, a message bus to send events for consumptions in applications that implement the MVVM design pattern as well as the Session class that manages a connection to a datasource.

## CDP4DalCommon

The CDP4DalCommon library provides common classes to support the ECSS-E-TM-10-25 and CDP4-COMET protocol.

## CDP4JsonFileDal

The CDP4JsonFileDal library is a C# library that provides an implementation of ECSS-E-TM-10-25A Annex C.3, the JSON Exchange File Format. This file format is a ZIP archive in which a number of files are stored that each contain one or more ECSS-E-TM-10-25 objects that are serialized in the form of a JSON array of JSON objects. The CDP4JsonFileDal library can be used to read from such a ZIP archive, and to create such a ZIP archive. The ZIP archive is typically used to exchange complete models between organizations.

## CDP4ServicesDal

The CDP4ServicesDal library is a C# library that provides an implementation of ECSS-E-TM-10-25A Annex C.2, the JSON REST API, which includes concepts that are specific to CDP4-COMET. These CDP4-COMET specific items are pure extensions of ECSS-E-TM-10-25A. The CDP4ServicesDal library can only be used to communicate with a CDP4-COMET Services instance, dedicated HTTP headers are used to verify that the REST API is indeed a COMET Services instance.

## CDP4Web

The CDP4Web library is a C# library that provides helpful classes that facilitate the use of the CDP4ServicesDal to any client.

## CDP4ServicesMessaging

The CDP4ServicesMessaging library is a C# library that provides abstractions over Rabbit MQ to support AMQP messaging

# Using the COMET SDK from Python

The repository contains a small helper that shows how to consume the COMET SDK
assemblies from an existing CPython environment by means of
[`pythonnet`](https://pythonnet.github.io/). The helper can be found in
`python/comet_session_wrapper.py` and demonstrates how to reproduce the C#
session bootstrap code from Python:

```python
from pathlib import Path

from comet_session_wrapper import CometSession, add_comet_references

# Point pythonnet to the directories that contain the built COMET assemblies.
add_comet_references([
    Path("/path/to/COMET-SDK-Community-Edition/CDP4Dal/bin/Release/net6.0"),
])

session = CometSession(
    url="https://cdp4services-public.cdp4.org",
    username="some-user-name",
    password="some-password",
)
session.connect()

# ... use session.session (the underlying CDP4Dal.Session instance) ...

session.disconnect()
```

To run the example:

1. Build the SDK (`dotnet build -c Release`) so that the required `.dll` files
   are available in the `bin` directories.
2. Install `pythonnet` in your Python environment, for example with
   `pip install pythonnet`.
3. Update the `add_comet_references` call so that it points to the build output
   directories on your machine.
4. Instantiate :class:`CometSession` with your credentials and call
   :py:meth:`CometSession.connect`.

# License

The libraries contained in the COMET-SDK Community Edition are provided to the community under the GNU Lesser General Public License. Because we make the software available with the LGPL, it can be used in both open source and proprietary software without being required to release the source code of your own components.

## Software Bill of Materials (SBOM)

As part of our commitment to security and transparency, this project includes a Software Bill of Materials (SBOM) in the associated NuGet packages. The SBOM provides a detailed inventory of the components and dependencies included in the package, allowing you to track and verify the software components, their licenses, and versions.

**Why SBOM?**

- **Improved Transparency**: Gain insight into the open-source and third-party components included in this package.
- **Security Assurance**: By providing an SBOM, we enable users to more easily track vulnerabilities associated with the included components.
- **Compliance**: SBOMs help ensure compliance with licensing requirements and make it easier to audit the project's dependencies.

You can find the SBOM in the NuGet package itself, which is automatically generated and embedded during the build process.

# Contributions

Contributions to the code-base are welcome. However, before we can accept your contributions we ask any contributor to sign the Contributor License Agreement (CLA) and send this digitaly signed to s.gerene@stariongroup.eu. You can find the CLA's in the CLA folder.