using System.Web.UI.WebControls.Expressions;
using Newtonsoft.Json;

namespace ViewAppointments.Models
{
   
    public class Text
    {
        
        [JsonProperty(Order= 1, PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(Order = 2, PropertyName = "div")]
        public string Div { get; set; }
    }
}