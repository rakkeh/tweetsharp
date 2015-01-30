using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    [DataContract]
    [DebuggerDisplay("{Code}: {Message}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterError : ITwitterModel
    {
        [DataMember]
        public virtual int Code { get; set; }

        [DataMember]
        public virtual string Message { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0}: {1}", Code, Message);
        }

        [DataMember]
        public virtual string RawSource { get; set; }
    }
}