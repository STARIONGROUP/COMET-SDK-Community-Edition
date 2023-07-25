<img src="https://github.com/RHEAGROUP/COMET-SDK-Community-Edition/raw/master/Comet_Logo.jpg" width="350">

> CDP4-COMET is the new name for what was previously called the CDP4. We are transitioning the applications and software libraries. The code and documentation will still refer to CDP4 in a number of places while we are updating.

The CDP4-COMET Software Development Kit is an C# SDK that that is compliant with ECSS-E-TM-10-25A Annex A and Annex C. The SDK contains multiple libraries that are each packaged as a nuget and avaialble from [nuget.org](https://www.nuget.org/packages?q=cdp4). The SDK is used in the CDP4-COMET to create an ECSS-E-TM-10-25A compliant implementation, both for the [Web Services](https://github.com/RHEAGROUP/COMET-WebServices-Community-Edition) and the [Desktop Application](https://github.com/RHEAGROUP/COMET-IME-Community-Edition). The following libraries are made avaiable in the Community Edition under the [GNU LGPL](https://www.gnu.org/licenses/lgpl-3.0.html):

  - CDP4Common
  - CDP4Rules
  - CDP4RequirementsVerification
  - CDP4JsonSerializer
  - CDP4MessagePackSerializer
  - CDP4Reporting
  - CDP4Dal
  - CDP4JsonFileDal
  - CDP4ServicesDal
  - CDP4WspDal

## Nuget

The SDK contains multiple libraries that are each packaged as a nuget and avaialble from [nuget.org](https://www.nuget.org/packages?q=cdp4).

Package | Link
--------|--------
CDP4Common | [![NuGet Badge](https://buildstats.info/nuget/CDP4Common-CE)](https://buildstats.info/nuget/CDP4Common-CE)
CDP4Rules | [![NuGet Badge](https://buildstats.info/nuget/CDP4Rules-CE)](https://buildstats.info/nuget/CDP4Rules-CE)
CDP4RequirementsVerification | [![NuGet Badge](https://buildstats.info/nuget/CDP4Rules-CE)](https://buildstats.info/nuget/CDP4RequirementsVerification-CE)
CDP4JsonSerializer | [![NuGet Badge](https://buildstats.info/nuget/CDP4JsonSerializer-CE)](https://buildstats.info/nuget/CDP4JsonSerializer-CE)
CDP4Reporting | [![NuGet Badge](https://buildstats.info/nuget/CDP4Reporting-CE)](https://buildstats.info/nuget/CDP4Reporting-CE)
CDP4Dal | [![NuGet Badge](https://buildstats.info/nuget/CDP4Dal-CE)](https://buildstats.info/nuget/CDP4Dal-CE)
CDP4JsonFileDal | [![NuGet Badge](https://buildstats.info/nuget/CDP4JsonFileDal-CE)](https://buildstats.info/nuget/CDP4JsonFileDal-CE)
CDP4ServicesDal | [![NuGet Badge](https://buildstats.info/nuget/CDP4ServicesDal-CE)](https://buildstats.info/nuget/CDP4ServicesDal-CE)
CDP4WspDal | [![NuGet Badge](https://buildstats.info/nuget/CDP4WspDal-CE)](https://buildstats.info/nuget/CDP4WspDal-CE)

## Build status

GitHub actions are used to build and test the libraries

Branch | Build Status
------- | :------------
Master | ![Build Status](https://github.com/RHEAGROUP/COMET-SDK-Community-Edition/actions/workflows/CodeQuality.yml/badge.svg?branch=master)
Development | ![Build Status](https://github.com/RHEAGROUP/COMET-SDK-Community-Edition/actions/workflows/CodeQuality.yml/badge.svg?branch=development)

## SonarQube Status:
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=RHEAGROUP_CDP4-SDK-Community-Edition&metric=alert_status)](https://sonarcloud.io/dashboard?id=RHEAGROUP_CDP4-SDK-Community-Edition)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=RHEAGROUP_CDP4-SDK-Community-Edition&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=RHEAGROUP_CDP4-SDK-Community-Edition)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=RHEAGROUP_CDP4-SDK-Community-Edition&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=RHEAGROUP_CDP4-SDK-Community-Edition)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=RHEAGROUP_CDP4-SDK-Community-Edition&metric=security_rating)](https://sonarcloud.io/dashboard?id=RHEAGROUP_CDP4-SDK-Community-Edition)

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=RHEAGROUP_CDP4-SDK-Community-Edition&metric=coverage)](https://sonarcloud.io/dashboard?id=RHEAGROUP_CDP4-SDK-Community-Edition)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=RHEAGROUP_CDP4-SDK-Community-Edition&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=RHEAGROUP_CDP4-SDK-Community-Edition)

[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=RHEAGROUP_CDP4-SDK-Community-Edition&metric=bugs)](https://sonarcloud.io/dashboard?id=RHEAGROUP_CDP4-SDK-Community-Edition)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=RHEAGROUP_CDP4-SDK-Community-Edition&metric=ncloc)](https://sonarcloud.io/dashboard?id=RHEAGROUP_CDP4-SDK-Community-Edition)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=RHEAGROUP_CDP4-SDK-Community-Edition&metric=sqale_index)](https://sonarcloud.io/dashboard?id=RHEAGROUP_CDP4-SDK-Community-Edition)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=RHEAGROUP_CDP4-SDK-Community-Edition&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=RHEAGROUP_CDP4-SDK-Community-Edition)

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

## CDP4JsonFileDal

The CDP4JsonFileDal library is a C# library that provides an implementation of ECSS-E-TM-10-25A Annex C.3, the JSON Exchange File Format. This file format is a ZIP archive in which a number of files are stored that each contain one or more ECSS-E-TM-10-25 objects that are serialized in the form of a JSON array of JSON objects. The CDP4JsonFileDal library can be used to read from such a ZIP archive, and to create such a ZIP archive. The ZIP archive is typically used to exchange complete models between organizations.

## CDP4ServicesDal

The CDP4ServicesDal library is a C# library that provides an implementation of ECSS-E-TM-10-25A Annex C.2, the JSON REST API, which includes concepts that are specific to CDP4-COMET. These CDP4-COMET specific items are pure extensions of ECSS-E-TM-10-25A. The CDP4ServicesDal library can only be used to communicate with a CDP4-COMET Services instance, dedicated HTTP headers are used to verify that the REST API is indeed a COMET Services instance.

## CDP4WspDal

The CDP4WspDal library is a C# library that provides an implementation of ECSS-E-TM-10-25A Annex C.2, the JSON REST API. The CDP4WspDal can be used to communicate with any ECSS-E-TM-10-25A Annex C.2 implementation, including the COMET Services.

# License

The libraries contained in the COMET-SDK Community Edition are provided to the community under the GNU Lesser General Public License. Because we make the software available with the LGPL, it can be used in both open source and proprietary software without being required to release the source code of your own components.

# Contributions

Contributions to the code-base are welcome. However, before we can accept your contributions we ask any contributor to sign the Contributor License Agreement (CLA) and send this digitaly signed to s.gerene@rheagroup.com. You can find the CLA's in the CLA folder.