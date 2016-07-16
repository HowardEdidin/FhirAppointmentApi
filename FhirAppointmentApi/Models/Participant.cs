using Newtonsoft.Json;

namespace FhirAppointmentApi.Models
{
    public class Participant
    {
        [JsonProperty("fhir_comments")]
        public FhirComments FhirComments { get; set; }

        [JsonProperty("actor")]
        public Actor Actor { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("required")]
        public string Required { get; set; }
    }
}