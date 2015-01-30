using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    [DataContract]
    [DebuggerDisplay("@{Value}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterUrl : TwitterEntity
    {
        [JsonProperty("url")]
        [DataMember]
        public virtual string Value { get; set; }

        [JsonProperty("expanded_url")]
        [DataMember]
        public virtual string ExpandedValue { get; set; }

        [JsonProperty("display_url")]
        [DataMember]
        public virtual string DisplayUrl { get; set; }

        public TwitterUrl()
        {
            Initialize();
        }

        private void Initialize()
        {
            EntityType = TwitterEntityType.Url;
        }
    }
}