using System;
using Newtonsoft.Json;

namespace FhirAppointmentApi.Models
{
    public class FhirComments
    {

        [JsonProperty("items")]
        public Array Items { get; set; }
    }
}