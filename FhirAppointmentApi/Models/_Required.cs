using Newtonsoft.Json;

namespace FhirAppointmentApi.Models
{
    // ReSharper disable once InconsistentNaming
    public class _Required
    {
        // ReSharper disasble once InconsistentNaming
        public FhirComments FireComments { get; set; }

        [JsonProperty("actor")]
        public Actor Actor { get; set; }



    }
}