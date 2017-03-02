using Newtonsoft.Json;
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
}
