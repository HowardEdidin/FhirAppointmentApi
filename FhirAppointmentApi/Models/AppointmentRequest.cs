using Newtonsoft.Json;

namespace FhirAppointmentApi.Models
{
    public class AppointmentRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }

        [JsonProperty("text")]
        public Text Text { get; set; }

        [JsonProperty("identifier")]
        public Identifier Identifier { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public Type Type { get; set; }

        [JsonProperty("reason")]
        public Reason Reason { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("minutesDuration")]
        public int MinutesDuration { get; set; }

        [JsonProperty("slot")]
        public Slot Slot { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("participant")]
        public Participant Participant { get; set; }

    }
}