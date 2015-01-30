using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    /* {"relationship": {
            "source": {
                "id": 123,
                "screen_name": "bob",
                "following": true,
                "followed_by": false,
                "notifications_enabled": false
     *      }
     *      ,
            "target": {
                "id": 456,
                "screen_name": "jack",
                "following": false,
                "followed_by": true,
                "notifications_enabled": null
     *      }
     *   }
     * }
     */

    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterFriendship : PropertyChangedBase, ITwitterModel
    {
        private TwitterRelationship _relationship;

        /// <summary>
        /// Gets or sets the relationship.
        /// </summary>
        /// <value>The relationship.</value>
        [DataMember]
        [JsonProperty("relationship")]
        public virtual TwitterRelationship Relationship
        {
            get { return _relationship; }
            set
            {
                if (_relationship == value)
                {
                    return;
                }

                _relationship = value;
                OnPropertyChanged("Relationship");
            }
        }

        [DataMember]
        public virtual string RawSource { get; set; }
    }
}