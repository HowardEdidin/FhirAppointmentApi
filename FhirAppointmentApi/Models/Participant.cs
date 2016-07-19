using System.Collections.Generic;
using Newtonsoft.Json;

namespace ViewAppointments.Models
{
    public class Participant
    {

        [JsonProperty(Order = 1, PropertyName = "actor")]
        public IList<Actor> Actor { get; set; }

        [JsonProperty(Order = 3, PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(Order = 2, PropertyName = "required")]
        public string Required { get; set; }

        [JsonProperty(Order = 4, PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Type> Type { get; set; }
    }
}