# CDP4-SDK Community Edition

> COMET is the new name for what was previously called the CDP4. We are transitioning the applications and software libraries. The code and documentation will still refer to CDP4 in a number of places while we are updating.

The COMET Software Development Kit is an C# SDK that that is compliant with ECSS-E-TM-10-25A Annex A and Annex C. The SDK contains multiple libraries that are each packaged as a nuget and avaialble from [nuget.org](https://www.nuget.org/packages?q=cdp). The SDK is used in COMET to create an ECSS-E-TM-10-25A compliant implementation, both for the [Web Services](https://github.com/RHEAGROUP/CDP4-WebServices-Community-Edition) and the [Desktop Application](https://github.com/RHEAGROUP/CDP4-IME-Community-Edition). The following libraries are made avaiable in the Community Edition under the [GNU AGPL](https://www.gnu.org/licenses/agpl-3.0.nl.html):

  - CDP4Common 
  - CDP4JsonSerializer
  - CDP4Dal
  - CDP4JsonFileDal
  - CDP4ServicesDal
  - CDP4WspDal

## CDP4Common

The CDP4Common library is a C# implementation of the COMET UML master model. The COMET UML master model is based on the ECSS-E-TM-10-25A Annex A UML master model and extends it with COMET concepts to improve the use of ECSS-E-TM-10-25A Annex A for Concurrent Design of complex systems. The library contains both [POCO](https://en.wikipedia.org/wiki/Plain_old_CLR_object) and [DTO](https://en.wikipedia.org/wiki/Data_transfer_object) implementations of the classes defined in the COMET UML master model. The POCO classes are used when a full object graph is required. The DTO's are used when a full object graph is not required, references to other class are represented by unique identifiers in the form of a GUID.

The CDP4Common library also includes a set of so-called MetaInfo classes. These classes are used to provide information about the classes in the UML master model such as the properties, relationships to other classes etc. These classes provide similar functionality as the C# reflection system, but with higher performance.

## CDP4JsonSerializer

The CDP4JsonSerializer library is an optimized CDP4Common specific JSON (de)serialization library that is used to serialize and deserialize the classes implemented in the CDP4Common class library. The (de)serialization makes use of the popular Json.NET framework to serialize and deserialize the CDP4Common DTO classes.

## CDP4Dal

The CDP4Dal library is a library that provides the basis to implement ECSS-E-TM-10-25A Annex C. Annex C specifies both the JSON REST API and the exchange file format. The CDP4Dal library contains the Assembler that is used to create a fully dereferenced object graph, a message bus to send events for consumptions in applications that implement the MVVM design pattern as well as the Session class that manages a connection to a datasource.

## CDP4JsonFileDal

The CDP4JsonFileDal library is a C# library that provides an implementation of ECSS-E-TM-10-25A Annex C.3, the JSON Exchange File Format. This file format is a ZIP archive in which a number of files are stored that each contain one or more ECSS-E-TM-10-25 objects that are serialized in the form of a JSON array of JSON objects. The CDP4JsonFileDal library can be used to read from such a ZIP archive, and to create such a ZIP archive. The ZIP archive is typically used to exchange complete models between organizations.

## CDP4ServicesDal

The CDP4ServicesDal library is a C# library that provides an implementation of ECSS-E-TM-10-25A Annex C.2, the JSON REST API, which includes concepts that are specific to COMET. These COMET specific items are pure extensions of ECSS-E-TM-10-25A. The CDP4ServicesDal library can only be used to communicate with a COMET Services instance, dedicated HTTP headers are used to verify that the REST API is indeed a COMET Services instance.

## CDP4WspDal

The CDP4WspDal library is a C# library that provides an implementation of ECSS-E-TM-10-25A Annex C.2, the JSON REST API. The CDP4WspDal can be used to communicate with any ECSS-E-TM-10-25A Annex C.2 implementation, including the COMET Services.

# License

The libraries contained in the COMET-SDK Community Edition are provided to the community under the GNU Affero General Public License. COMET Community Edition, which makes use of the COMET-SDK Community Edition, relies on open source and proprietary licensed components. Some of these components have a license that is not compatible with the GPL or AGPL. For these components Additional permission under GNU GPL version 3 section 7 are granted. See the license files for the details. The license can be found [here](LICENSE).

# Contributions

Contributions to the code-base are welcome. However, before we can accept your contributions we ask any contributor to sign the Contributor License Agreement (CLA) and send this digitaly signed to s.gerene@rheagroup.com. You can find the CLA's in the CLA folder.