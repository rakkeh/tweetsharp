using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterRateLimitResource
    {
        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual Dictionary<string, TwitterRateLimitStatus> Limits { get; set; }
    }
}