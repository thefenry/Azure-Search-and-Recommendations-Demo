using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace AzureSearchService
{
    public class AzureSearchManager
    {
        private readonly SearchServiceClient _searchClient;

        public AzureSearchManager()
        {
            string searchServiceName = ConfigurationManager.AppSettings["SearchServiceName"];
            string adminApiKey = ConfigurationManager.AppSettings["SearchServiceAdminApiKey"];

            _searchClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));
        }


        public void CreateIndex<T>(string indexName)
        {
            if (_searchClient.Indexes.Exists(indexName))
            {
                return;
            }

            var definition = new Index()
            {
                Name = indexName,
                Fields = FieldBuilder.BuildForType<T>()
            };

            Field field = definition.Fields.FirstOrDefault(x => x.IsKey && x.Type != DataType.String);
            field.Type = DataType.String;


            _searchClient.Indexes.Create(definition);
        }


        public void CreateIndex(Index definition)
        {
            _searchClient.Indexes.Create(definition);
        }


        public DocumentIndexResult AddOrUpdateDocumentToIndex<T>(List<T> documents, string indexName) where T : class, new()
        {
            ISearchIndexClient indexClient = _searchClient.Indexes.GetClient(indexName);
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
        
        public DocumentIndexResult DeleteDocumentInIndex<T>(List<T> documents, string indexName) where T : class, new()
        {
            ISearchIndexClient indexClient = _searchClient.Indexes.GetClient(indexName);
            IndexBatch<T> batch = IndexBatch.Delete(documents);

            try
            {
                return indexClient.Documents.Index(batch);
            }
            catch (IndexBatchException e)
            {
                throw e;
            }
        }
    }
}
