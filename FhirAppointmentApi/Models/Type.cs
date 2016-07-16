using Newtonsoft.Json;

namespace FhirAppointmentApi.Models
{
    public class Type
    {

        [JsonProperty("coding")]
        public Coding Coding { get; set; }
    }
}