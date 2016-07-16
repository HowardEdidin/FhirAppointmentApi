using Newtonsoft.Json;

namespace FhirAppointmentApi.Models
{
    public class Reason
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}