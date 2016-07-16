using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using FhirAppointmentApi.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Swashbuckle.Swagger.Annotations;
using TRex.Metadata;

namespace FhirAppointmentApi.Controllers
{
    public class AppointmentController : ApiController
    {
        private static DocumentClient _client;

        [HttpPost]
        [Metadata("SavePatientAppoimentAsync", "Inserts a new appoinment request message in DocDb")]
        [SwaggerOperation("SavePatientAppoimentRequestAsync")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<dynamic> SavePatientAppoimentRequestAsync(
            [Metadata("Appointment", "Appointment Request Body")] [FromBody] AppointmentRequest appoinment)
        {
            _client = new DocumentClient(new Uri(DocumentDbContext.EndPoint), DocumentDbContext.AuthKey);

            var collectionLink = UriFactory.CreateDocumentCollectionUri(DocumentDbContext.DatabaseId,
                DocumentDbContext.CollectionId);


            dynamic appointmentRequest = new
            {
                id = appoinment.Id + "-" + Math.Truncate(Utility.ConvertToTimestamp(DateTime.UtcNow)),
                patientId = appoinment.Id,
                timestamp = DateTime.UtcNow,
                text = appoinment.Text,
                identifier = appoinment.Identifier,
                status = appoinment.Status,
                type = appoinment.Type,
                reason = appoinment.Reason,
                priority = appoinment.Priority,
                description = appoinment.Description,
                minutesDuration = appoinment.MinutesDuration,
                slot = appoinment.Slot,
                comment = appoinment.Comment,
                participant = appoinment.Participant
            };

            ResourceResponse<Document> response =
                await
                    _client.CreateDocumentAsync(collectionLink, appointmentRequest, disableAutomaticIdGeneration: true);
            var createdDocument = response.Resource;
            return createdDocument;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="documentId"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        [Route("attachment")]
        [HttpPost]
        [Metadata("AddAttachmentAsync", "Appends attachment to document")]
        [SwaggerOperation("AddAttachmentAsync")]
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<ResourceResponse<Attachment>> AddAttachmentAsync(
            [Metadata("Filename", "Filename and path from Blob storage account")] string filename,
            [Metadata("Document Id", "The Id of the Document")] string documentId,
            [Metadata("MediaType","The media type for the file")] string mediaType,
             [Metadata("Suffix", "The suffix for the attachment Id")] string suffix )
        {
            _client = new DocumentClient(new Uri(DocumentDbContext.EndPoint), DocumentDbContext.AuthKey);

            var doc = UriFactory.CreateDocumentUri(DocumentDbContext.DatabaseId, DocumentDbContext.CollectionId,
                documentId);


            return
                await
                    _client.CreateAttachmentAsync(doc,
                        new Attachment {Id = documentId + suffix, ContentType = mediaType, MediaLink = filename});
        }
    }
}