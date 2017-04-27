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
        private SearchIndexClient _indexClient;

        private string SearchServiceName
        {
            get { return ConfigurationManager.AppSettings["SearchServiceName"]; }
        }

        public string AdminApiKey
        {
            get { return ConfigurationManager.AppSettings["SearchServiceAdminApiKey"]; }
        }
                
        public AzureSearchManager(string indexName)
        {
            _searchClient = new SearchServiceClient(SearchServiceName, new SearchCredentials(AdminApiKey));
            _indexClient = GetIndexClient(indexName);
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


        public DocumentIndexResult AddOrUpdateDocumentToIndex<T>(List<T> documents) where T : class, new()
        {          
            IndexBatch<T> batch = IndexBatch.Upload(documents);

            try
            {
                return _indexClient.Documents.Index(batch);
            }
            catch (IndexBatchException e)
            {
                throw e;
            }
        }

        public DocumentIndexResult DeleteDocumentInIndex<T>(List<T> documents) where T : class, new()
        {           
            IndexBatch<T> batch = IndexBatch.Delete(documents);

            try
            {
                return _indexClient.Documents.Index(batch);
            }
            catch (IndexBatchException e)
            {
                throw e;
            }
        }

        public DocumentSearchResult<T> GetAllResults<T>() where T : class, new()
        {           
            return _indexClient.Documents.Search<T>("*");
        }

        public DocumentSearchResult<T> SearchContent<T>(string searchTerm) where T : class, new()
        {
            return _indexClient.Documents.Search<T>(searchTerm);
        }

        public DocumentSearchResult<T> FilterContent<T>(string filter) where T : class, new()
        {
            SearchParameters parameters = new SearchParameters()
            {
                Filter = filter,
                Select = new[] { "hotelId", "description" }
            };
             return _indexClient.Documents.Search<T>("*", parameters);
        }

        private SearchIndexClient GetIndexClient(string indexName)
        {
            return new SearchIndexClient(SearchServiceName, indexName, new SearchCredentials(AdminApiKey));
        }
    }
}
