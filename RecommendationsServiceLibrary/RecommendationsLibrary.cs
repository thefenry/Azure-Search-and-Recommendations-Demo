using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;

namespace RecommendationsServiceLibrary
{
    public class RecommendationsLibrary
    {
        private string BaseUri;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor that initializes the Http Client.
        /// </summary>
        /// <param name="accountKey">The account key</param>
        public RecommendationsLibrary(string accountKey, string baseUri)
        {
            BaseUri = baseUri;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUri),
                Timeout = TimeSpan.FromMinutes(15),
                DefaultRequestHeaders =
                {
                    {"Ocp-Apim-Subscription-Key", accountKey}
                }
            };
        }

        /// <summary>
        /// Creates a new model.
        /// </summary>
        /// <param name="modelName">Name for the model</param>
        /// <param name="description">Description for the model</param>
        /// <returns>Model Information.</returns>
        public ModelInfo CreateModel(string modelName, string description = null)
        {
            var uri = BaseUri + "/models/";
            var modelRequestInfo = new ModelRequestInfo { ModelName = modelName, Description = description };
            var response = _httpClient.PostAsJsonAsync(uri, modelRequestInfo).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(string.Format("Error {0}: Failed to create model {1}, \n reason {2}",
                    response.StatusCode, modelName, response.Content));
            }

            var responseJson = response.Content.ReadAsStringAsync().Result;
            var modelInfo = JsonConvert.DeserializeObject<ModelInfo>(responseJson);
            return modelInfo;
        }

        public object UploadModel(string modelId, string fileName, string fileUrl)
        {

            string uri = BaseUri + "/models/" + modelId + "/catalog?catalogDisplayName=" + fileName;

            using (var filestream = new FileStream(fileUrl, FileMode.Open, FileAccess.Read))
            {
                var response = _httpClient.PostAsync(uri, new StreamContent(filestream)).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        string.Format("Error {0}: Failed to import catalog items {1}, for model {2} \n reason {3}",
                            response.StatusCode, fileUrl, modelId, response.Content));
                }

                string responseJson = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<CatalogImportStats>(responseJson);
            }
        }
    }
}
