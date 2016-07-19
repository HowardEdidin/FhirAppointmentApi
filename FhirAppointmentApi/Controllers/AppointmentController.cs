using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ViewAppointments.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Swashbuckle.Swagger.Annotations;
using TRex.Metadata;

namespace ViewAppointments.Controllers
{
    public class AppointmentController : ApiController
    {
        private static DocumentClient _client;

        [Route("NewApppoitnment")]
        [HttpPost]
        [Metadata("CreateAppointmenTaskAsync", "Inserts a new appoinment request message in DocDb")]
        [SwaggerOperation("CreateAppointmenTask")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<ResourceResponse<Document>> CreateAppointmenTaskAsync(object document, string id)
        {
            

            _client = new DocumentClient(new Uri(DocumentDbContext.EndPoint), DocumentDbContext.AuthKey);

            var collectionLink = UriFactory.CreateDocumentCollectionUri(DocumentDbContext.DatabaseId,
                DocumentDbContext.CollectionId);

        
          

            var doc =
                await _client.CreateDocumentAsync(collectionLink, new {id, document, HasAttachment = true }, null,  true);
            return doc;

        }


        [HttpPost]
        [Metadata("SavePatientAppointmentRequest", "Inserts a new appoinment request message in DocDb")]
        [SwaggerOperation("SavePatientAppointmentRequest")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<dynamic> SavePatientAppointmentRequestAsync(
            [Metadata("Appointment", "Appointment Request Body")] [FromBody] AppointmentRequest appointment)
        {
            _client = new DocumentClient(new Uri(DocumentDbContext.EndPoint), DocumentDbContext.AuthKey);

            var collectionLink = UriFactory.CreateDocumentCollectionUri(DocumentDbContext.DatabaseId,
                DocumentDbContext.CollectionId);


            dynamic appointmentRequest = new
            {
                id = appointment.Id + "-" + Math.Truncate(Utility.ConvertToTimestamp(DateTime.UtcNow)),
                timestamp = DateTime.UtcNow,
                status = appointment.Status,
                priority = appointment.Priority,
                description = appointment.Description,
                comment = appointment.Comment,
                start = appointment.Start,
                end = appointment.End,
                hasAttachment = true
            };

            ResourceResponse<Document> response =
                await
                    _client.CreateDocumentAsync(collectionLink, appointmentRequest, disableAutomaticIdGeneration: true);
            var createdDocument = response.Resource;
            return createdDocument;
        }
        

        /// <summary>
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="documentId"></param>
        /// <param name="mediaType"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        [Route("attachment")]
        [HttpPost]
        [Metadata("AddAttachment", "Appends attachment to document")]
        [SwaggerOperation("AddAttachment")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<ResourceResponse<Attachment>> AddAttachmentAsync(
            [Metadata("Filename", "Filename and path from Blob storage account")] string filename,
            [Metadata("Document Id", "The Id of the Document")] string documentId,
            [Metadata("MediaType", "The media type for the file")] string mediaType,
            [Metadata("Suffix", "The suffix for the attachment Id")] string suffix)
        {
            _client = new DocumentClient(new Uri(DocumentDbContext.EndPoint), DocumentDbContext.AuthKey);

            var doc = UriFactory.CreateDocumentUri(DocumentDbContext.DatabaseId, DocumentDbContext.CollectionId,
                documentId);


            return
                await
                    _client.CreateAttachmentAsync(doc,
                        new Attachment {Id = documentId + suffix, ContentType = mediaType, MediaLink = filename});
        }


        /// <summary>
        /// </summary>
        /// <param name="currentdateTime"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation("GetAttachmentSufffix")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public double GetAttachmentSuffix(
            [Metadata("Current DateTime")] string currentdateTime)
        {
            var uncoded = HttpContext.Current.Server.UrlDecode(currentdateTime);
            var newDateTime = DateTime.Parse(uncoded);

            var span = newDateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();


            return Math.Truncate(span.TotalSeconds);
        }
    }
}