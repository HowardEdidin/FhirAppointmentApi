using System;
using Newtonsoft.Json;

namespace ViewAppointments.Models
{
    public class FhirComments
    {

        [JsonProperty("items")]
        public Array Items { get; set; }
    }
}