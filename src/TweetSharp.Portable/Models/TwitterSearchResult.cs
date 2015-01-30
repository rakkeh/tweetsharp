using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    [DataContract]
    [DebuggerDisplay("{Statuses}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterSearchResult : ITwitterModel
    {
        [JsonProperty("statuses")]
        [DataMember]
        public virtual IEnumerable<TwitterStatus> Statuses { get; set; }

        [DataMember]
        public virtual string RawSource { get; set; }
    }
}