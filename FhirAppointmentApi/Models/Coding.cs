using Newtonsoft.Json;

namespace FhirAppointmentApi.Models
{
    public class Coding
    {

        [JsonProperty("code")]
        public string Code { get; set; }


        [JsonProperty("display")]
        public string Display { get; set; }
    }
}