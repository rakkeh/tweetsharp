using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterTrend : PropertyChangedBase, ITwitterModel
    {
        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string Url { get; set; }

        [DataMember]
        public virtual string Query { get; set; }

        [DataMember]
        public virtual string Events { get; set; }

        [DataMember]
        public virtual string PromotedContent { get; set; }

        [DataMember]
        public virtual DateTime TrendingAsOf { get; set; }

        [DataMember]
        public virtual string RawSource { get; set; }
    }
}