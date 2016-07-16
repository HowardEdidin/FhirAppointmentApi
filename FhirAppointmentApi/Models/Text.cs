using Newtonsoft.Json;

namespace FhirAppointmentApi.Models
{
    public class Text
    {


        [JsonProperty("div")]
        public string Div { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}