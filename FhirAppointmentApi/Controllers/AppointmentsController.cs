using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Swashbuckle.Swagger.Annotations;
using TRex.Metadata;

namespace ViewAppointments.Controllers
{
    public class AppointmentsController : ApiController
    {
        private static DocumentClient _client;


        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Metadata("ReadDocumentById", "Get a document by its Id")]
        [Route("Document")]
        [HttpGet]
        [SwaggerOperation("ReadDocumentByIdAsync")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.Found)]
        public async Task<ResourceResponse<Document>> ReadDocumentByIdAsync(
            [Metadata("Id", "Document Id") ]string id)
        {
            var doclLink = UriFactory.CreateDocumentUri(DocumentDbContext.DatabaseId, DocumentDbContext.CollectionId, id);

            var response =
                await
                    _client.ReadDocumentAsync(doclLink);

            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="docid"></param>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        [Metadata("ReadAttachmentAsync", "Get an Attachment for Document")]
        [Route("Attachments")]
        [HttpGet]
        [SwaggerOperation("ReadAttachmentAsync")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.Found)]
        public async Task<ResourceResponse<Attachment>> ReadAttachmentAsync(
          [Metadata("DocId", "Document Id") ] string docid, 
          [Metadata("attachmentId", "Attachment Id")]  string attachmentId)
        {
            var doclLink = UriFactory.CreateAttachmentUri(DocumentDbContext.DatabaseId, DocumentDbContext.CollectionId, docid, attachmentId);

            var response = await
                _client.ReadAttachmentAsync(doclLink);

            return response;
        }

        [Metadata("UpsertDocumenTaskAsync", "Upserts  an Document")]
        [HttpPost]
        [SwaggerOperation("UpsertDocumenTaskAsync")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.Found)]
        public async Task<ResourceResponse<Document>> UpsertDocumenTaskAsync(object doc, string id)
        {
            var doclLink = UriFactory.CreateDocumentCollectionUri(DocumentDbContext.DatabaseId, DocumentDbContext.CollectionId);

            var response = await _client.UpsertDocumentAsync(doclLink, new {id, doc}, null, true);

            return response;

        }
    }
}