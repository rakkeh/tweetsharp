using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    /// <summary>
    /// Represents the relationship between two users on Twitter
    /// as they related to each <see cref="TwitterFriend" /> representation.
    /// </summary>
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterRelationship : PropertyChangedBase, ITwitterModel
    {
        private TwitterFriend _source;
        private TwitterFriend _target;

        /// <summary>
        /// Gets or sets the relative source of the relationship.
        /// </summary>
        /// <value>The source.</value>
        [DataMember]
        [JsonProperty("source")]
        public virtual TwitterFriend Source
        {
            get { return _source; }
            set
            {
                if (_source == value)
                {
                    return;
                }

                _source = value;
                OnPropertyChanged("Source");
            }
        }

        /// <summary>
        /// Gets or sets the relative target of the relationship.
        /// </summary>
        /// <value>The target.</value>
        [DataMember]
        [JsonProperty("target")]
        public virtual TwitterFriend Target
        {
            get { return _target; }
            set
            {
                if (_target == value)
                {
                    return;
                }

                _target = value;
                OnPropertyChanged("Target");
            }
        }

        [DataMember]
        public virtual string RawSource { get; set; }
    }
}