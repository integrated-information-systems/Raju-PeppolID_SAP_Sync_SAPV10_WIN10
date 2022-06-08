using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeppolID_Sync.Business
{
    public class PeppolJSONConverter
    {
        public List<Participant> participants { get; set; }
        public int count { get; set; }
        public int total { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ParticipantIdentifier
    {
        public string participantIdentifierSchema { get; set; }
        public string participantIdentifierTypeCode { get; set; }
        public string participantIdentifierValue { get; set; }
        public string fullyQualifiedParticipantIdentifier { get; set; }
    }

    public class ContactDto
    {
        public string type { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
    }

    public class MultilingualNameDto
    {
        public string name { get; set; }
        public string languageCode { get; set; }
        public bool main { get; set; }
    }

    public class BusinessEntityDto
    {
        public int id { get; set; }
        public List<ContactDto> contactDtos { get; set; }
        public List<object> identifierDtos { get; set; }
        public List<MultilingualNameDto> multilingualNameDtos { get; set; }
        public List<object> websiteUriDtos { get; set; }
        public string countryCode { get; set; }
        public string geographicalInformation { get; set; }
        public string additionalInformation { get; set; }
    }

    public class SupportedDocument
    {
        public string name { get; set; }
    }

    public class Participant
    {
        public int id { get; set; }
        public ParticipantIdentifier participantIdentifier { get; set; }
        public long registered { get; set; }
        public List<BusinessEntityDto> businessEntityDtos { get; set; }
        public List<SupportedDocument> supportedDocuments { get; set; }
    }

    public class Root
    {
       
    }
}
