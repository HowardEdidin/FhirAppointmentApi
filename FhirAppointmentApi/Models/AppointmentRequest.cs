using System;
using Newtonsoft.Json;

namespace ViewAppointments.Models
{
    public class AppointmentRequest
    {
        [JsonProperty(Order = 1, PropertyName = "id")]
        public string Id { get; set; }


        [JsonProperty(Order = 2, PropertyName = "status")]
        public string Status { get; set; }


        [JsonProperty(Order = 3, PropertyName = "priority")]
        public int Priority { get; set; }

        [JsonProperty(Order = 4, PropertyName = "description")]
        public string Description { get; set; }


        [JsonProperty(Order = 7, PropertyName = "comment")]
        public string Comment { get; set; }


        [JsonProperty(Order = 5, PropertyName = "start")]
        public DateTime Start { get; set; }

        [JsonProperty(Order = 6, PropertyName = "end")]
        public DateTime End { get; set; }
    }
}