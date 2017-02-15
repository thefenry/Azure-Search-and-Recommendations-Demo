using System;
using System.Collections.Generic;
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


        public DocumentIndexResult AddOrUpdateDocumentToIndex<T>(List<T> documents, string indexName) where T : class, new()
        {
            ISearchIndexClient indexClient = _serviceClient.Indexes.GetClient(indexName);
            IndexBatch<T> batch = IndexBatch.Upload(documents);

            try
            {
                return indexClient.Documents.Index(batch);
            }
            catch (IndexBatchException e)
            {
                throw e;
            }
        }


        //public void UpdateIndex<TData>(TData entity) where TData : class
        //{
        //    ISearchIndexClient indexClient = _serviceClient.Indexes.GetClient("cars");

        //    //var actions = new IndexAction
        //    //{
        //    //}
        //    var test = IndexAction.Upload<Index>(entity);

        //    indexClient.Documents.Index(test);



        //}

        //public void UpdateIndex<T>(List<T> test, string v)
        //{
        //    ISearchIndexClient indexClient = _serviceClient.Indexes.GetClient("cars");

        //    indexClient.Documents.Index(test)

        //    var batch = IndexBatch.New(test);

        //    throw new NotImplementedException();
        //}
    }
}
