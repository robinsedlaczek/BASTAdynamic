using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace BASTA_dynamics_Userlib_db
{
    public class CosmosConnector
    {
        private const string EndpointUri = @"https://cf42c612-0ee0-4-231-b9ee.documents.azure.com:443/";
        private const string PrimaryKey = @"VoV3TzErmDnI7UK3VWZAKADQqjejjdoo30EMR1ps2YdBDqtisXdR6WCD4aKagwOTwz69axUh1NQzZEcDXStMNA==";
        private const string CDName = "BastaDynamics";
        private const string CollName = "Data";
        private DocumentClient client;

        CosmosConnector()
        {
            client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);

        }

        private async void Initiate()
        {
            await this.client.CreateDatabaseIfNotExistsAsync(new Database { Id = CDName });
            await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(CDName), new DocumentCollection { Id = CollName });

        }
        private async Task CreateDocumentIfNotExists(string databaseName, string collectionName, DBObject dBObject)
        {
            try
            {
                await this.client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, dBObject.Id), dBObject);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), dBObject);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task DeleteDocument(string databaseName, string collectionName, string documentName)
        {
            try
            {
                await this.client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, documentName));
            }
            catch (DocumentClientException de)
            {
                throw;
            }
        }

        public async CompanyObject[] GetCompany(string filter = "")
        {

        }
        
        public async Task SetCompany(CompanyObject input)
        {
            await CreateDocumentIfNotExists(CDName, CollName, input);
        }
        public async Task DelCompany(CompanyObject input)
        {
            await DeleteDocument(CDName, CollName, input.Id);
        }

        public async CompanyObject[] GetEmployee(string filter = "")
        {

        }

        public async Task SetEmployee(CompanyObject input)
        {
            await this.CreateDocumentIfNotExists(CDName, CollName, input);
        }
        public async Task DelEmployee(CompanyObject input)
        {
            await DeleteDocument(CDName, CollName, input.Id);
        }
    }
    public class DBObject
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Address { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class CompanyObject : DBObject
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class EmployeeObject : DBObject
    {
        [JsonProperty(PropertyName = "firstname")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string Lastname { get; set; }
        
        [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }

    }
}
