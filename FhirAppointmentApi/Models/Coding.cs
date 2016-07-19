using Newtonsoft.Json;

namespace ViewAppointments.Models
{
    public class Coding
    {

        [JsonProperty("code")]
        public string Code { get; set; }


        [JsonProperty(PropertyName = "display", Required = Required.AllowNull)]
        public string Display { get; set; }
    }
}