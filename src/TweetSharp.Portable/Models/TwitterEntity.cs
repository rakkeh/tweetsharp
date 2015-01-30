using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class TwitterEntity : IComparable<TwitterEntity>, IComparer<TwitterEntity>
    {
        [JsonProperty("indices")]
        [DataMember]
        public virtual IList<int> Indices { get; set; }

        [DataMember]
        public virtual TwitterEntityType EntityType { get; protected set; }

        [DataMember]
        public virtual int StartIndex
        {
            get { return Indices.Count > 0 ? Indices[0] : -1; }
        }

        [DataMember]
        public virtual int EndIndex
        {
            get { return Indices.Count > 1 ? Indices[1] : -1; }
        }

        public virtual int CompareTo(TwitterEntity other)
        {
            return StartIndex.CompareTo(other.StartIndex);
        }

        public virtual int Compare(TwitterEntity x, TwitterEntity y)
        {
            return x.StartIndex.CompareTo(y.StartIndex);
        }
    }
}