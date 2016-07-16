using Newtonsoft.Json;

namespace FhirAppointmentApi.Models
{
    public class Slot
    {

        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}