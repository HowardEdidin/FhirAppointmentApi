using System;
using Newtonsoft.Json;

namespace ViewAppointments.Models
{
    
    public class Actor
    {
        [JsonProperty(Order = 1, PropertyName = "reference", Required = Required.Always)]
        public string Reference { get; set; }

        [JsonProperty(Order = 2, PropertyName = "display", Required = Required.Always)]
        public string Display { get; set; }


        


        
    }
}