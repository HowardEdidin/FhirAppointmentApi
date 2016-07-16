using Newtonsoft.Json;

namespace FhirAppointmentApi.Models
{
    public class Identifier
    {
        [JsonProperty("system")]
        public string System { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

    }
}