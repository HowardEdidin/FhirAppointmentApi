using Newtonsoft.Json;

namespace FhirAppointmentApi.Models
{
    public class Actor
    {
        [JsonProperty("display")]
        public string Display { get; set; }


        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}