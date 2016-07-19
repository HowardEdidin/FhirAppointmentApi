using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ViewAppointments.Models
{
    public class AppointmentRequest
    {
        // ReSharper disable once InconsistentNaming

        [JsonProperty("id")]
        [JsonRequired]
        public string id { get; set; }

        [JsonProperty("status")]
        [JsonRequired]
        public string Status { get; set; }

        [JsonProperty("priority")]
        [JsonRequired]
        public int Priority { get; set; }

        [JsonProperty("description")]
        [JsonRequired]
        public string Description { get; set; }

        [JsonProperty("start")]
        [JsonRequired]
        public DateTime Start { get; set; }

        [JsonProperty("end")]
        [JsonRequired]
        public DateTime End { get; set; }

        [JsonProperty("comment")]
        [JsonRequired]
        public string Comment { get; set; }

        [JsonProperty("timestamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("hasAttachment")]
        [DefaultValue(true)]
        public bool HasAttachment { get; set; }


    }
}