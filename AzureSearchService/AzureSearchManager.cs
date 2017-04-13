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

        private string SearchServiceName
        {
            get { return ConfigurationManager.AppSettings["SearchServiceName"]; }            
        }

        public string AdminApiKey
        {
            get { return ConfigurationManager.AppSettings["SearchServiceAdminApiKey"]; }            
        }

        public AzureSearchManager()
        {
            _searchClient = new SearchServiceClient(SearchServiceName, new SearchCredentials(AdminApiKey));
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

        public DocumentSearchResult<T> GetAllResults<T>(string indexName) where T : class, new()
        {
            SearchIndexClient indexClient = GetIndexClient(indexName);

            return indexClient.Documents.Search<T>("*");
        }
        
        public DocumentSearchResult<T> SearchContent<T>(string indexName, string searchTerm) where T : class, new()
        {          
            SearchIndexClient indexClient = GetIndexClient(indexName);

            return indexClient.Documents.Search<T>(searchTerm);
        }

        private SearchIndexClient GetIndexClient(string indexName)
        {
            return new SearchIndexClient(SearchServiceName, indexName, new SearchCredentials(AdminApiKey));
        }
    }
}
