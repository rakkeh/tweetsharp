using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterRateLimitStatusSummary 
    {
        [DataMember]
        public virtual string AccessToken { get; set; }

        [DataMember]
        public virtual List<TwitterRateLimitResource> Resources { get; set; }

        [DataMember]
        public virtual string RawSource { get; set; }
    }
}