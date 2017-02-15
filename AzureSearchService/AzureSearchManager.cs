using System.Configuration;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace AzureSearchService
{
    public class AzureSearchManager
    {
        private readonly SearchServiceClient _serviceClient;

        public AzureSearchManager()
        {
            string searchServiceName = ConfigurationManager.AppSettings["SearchServiceName"];
            string adminApiKey = ConfigurationManager.AppSettings["SearchServiceAdminApiKey"];

            _serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));
        }
        public void CreateIndex(Index definition)
        {
            _serviceClient.Indexes.Create(definition);
        }

        public void UpdateIndex<TData>(TData entity) where TData : class
        {
            //var unknown = entity.GetType().GetMethod("MyFunction").Invoke(entity, null);

            //var definition = new Index()
            //{
            //    Name = "hotels",
            //Fields = FieldBuilder.BuildForType<unknown>()
            //};

           //GetEntityIndexInfo(entity, "update");
        }

 

       
    }
}
