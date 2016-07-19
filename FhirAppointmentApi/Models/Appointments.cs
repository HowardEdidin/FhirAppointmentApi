using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FhirAppointmentApi.Models
{
    public class Appointments
    {
        [JsonProperty(Order = 2, PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(Order = 1, PropertyName = "resourceType")]
        public string ResourceType { get; set; }

        [JsonProperty(Order = 3, PropertyName = "text")]
        public string Text { get; set; }
        

        [JsonProperty(Order = 4, PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(Order = 5, PropertyName = "type")]
        public string Type { get; set; }

        //public Identifier Identifier { get; set; }

        [JsonProperty(Order = 6, PropertyName = "priority")]
        public string Priority { get; set; }

        [JsonProperty(Order = 7, PropertyName = "description")]
        public string Description { get; set; }


        [JsonProperty(Order = 10, PropertyName = "comment")]
        public string Comment { get; set; }

        [JsonProperty(Order = 11, PropertyName = "participant")]
        public IList<Actor> Participant { get; set; }

        [JsonProperty(Order = 8, PropertyName = "start")]
        public DateTime Start { get; set; }

        [JsonProperty(Order = 9, PropertyName = "end")]
        public DateTime End { get; set; }

    }
}