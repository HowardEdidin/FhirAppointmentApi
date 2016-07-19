using Newtonsoft.Json;

namespace ViewAppointments.Models
{
    public class Reason
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "text")]
        public string Text { get; set; }
    }
}