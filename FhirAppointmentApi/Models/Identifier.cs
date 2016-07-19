using Newtonsoft.Json;

namespace ViewAppointments.Models
{
    public class Identifier
    {
        [JsonProperty("system")]
        public string System { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

    }
}