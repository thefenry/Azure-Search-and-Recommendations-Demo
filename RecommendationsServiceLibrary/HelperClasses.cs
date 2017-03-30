using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RecommendationsServiceLibrary
{
    [DataContract]
    public class ModelRequestInfo
    {
        [DataMember]
        [JsonProperty("modelName")]
        public string ModelName { get; set; }

        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    [DataContract]
    public class ModelInfo
    {
        [DataMember]
        [JsonProperty("id")]
        public string Id { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        [DataMember]
        [JsonProperty("createdDateTime")]
        public string CreatedDateTime { get; set; }

        [DataMember]
        [JsonProperty("activeBuildId")]
        public long ActiveBuildId { get; set; }

    }

    [DataContract]
    public class CatalogImportStats
    {
        [DataMember]
        [JsonProperty("processedLineCount")]
        public int ProcessedLineCount { get; set; }

        [DataMember]
        [JsonProperty("errorLineCount")]
        public int ErrorLineCount { get; set; }

        [DataMember]
        [JsonProperty("importedLineCount")]
        public int ImportedLineCount { get; set; }

        [DataMember]
        [JsonProperty("errorSummary")]
        public IEnumerable<ImportErrorStats> ErrorSummary { get; set; }

    }

    [DataContract]
    public class ImportErrorStats
    {
        [DataMember]
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [DataMember]
        [JsonProperty("errorCodeCount")]
        public int ErrorCodeCount { get; set; }
    }
}
