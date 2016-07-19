using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace ViewAppointments
{
    public static class DocumentDbRepository<T> where T : class
    {
        // ReSharper disable once StaticMemberInGenericType
        private static readonly string DatabaseId = ConfigurationManager.AppSettings["DatabaseId"];
        // ReSharper disable once StaticMemberInGenericType
        private static readonly string CollectionId = ConfigurationManager.AppSettings["CollectionId"];
        // ReSharper disable once StaticMemberInGenericType
        private static DocumentClient _client;


        public static void Initialize()
        {
            _client = new DocumentClient(new Uri(ConfigurationManager.AppSettings["endpoint"]),
                ConfigurationManager.AppSettings["AuthKey"]);
        }

        public static async Task DeleteItemAsync(string id)
        {
            await _client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
        }


        /// <summary>
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            var results = new List<T>();

            var query = _client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId))
                .Where(predicate)
                .AsDocumentQuery();


            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }


        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <summary>
        ///     Update the Document
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static async Task<Document> UpdateItemAsync(string id, T item)
        {
            return await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id), item);
        }

        /// <summary>
        ///     Get Error Detail Record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<T> GetItemAsync(string id)
        {
            try
            {
                Document document =
                    await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
                return (T) (dynamic) document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }
        }
    }
}