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

        public async CompanyObject[] GetCompany(string filter = "")
        {

        }
        
        public async bool SetCompany(CompanyObject input)
        {

        }
        public async bool DelCompany(CompanyObject input)
        {

        }

        public async CompanyObject[] GetEmployee(string filter = "")
        {

        }

        public async bool SetEmployee(CompanyObject input)
        {

        }
        public async bool DelEmployee(CompanyObject input)
        {

        }
    }

    public class CompanyObject
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Address { get; set; }
    }

    public class EmployeeObject
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string Lastname { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        
    }
}
