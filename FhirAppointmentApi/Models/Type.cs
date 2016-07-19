using System.Collections.Generic;
using Newtonsoft.Json;

namespace ViewAppointments.Models
{
    public class Type
    {

        [JsonProperty("coding")]
        public IList<Coding> Coding { get; set; }
    }
}