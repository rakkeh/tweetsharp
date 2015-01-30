using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
/* 
{
    "name": "Twitter",
    "id_str": "783214",
    "id": 783214,
    "connections": [
        "following",
        "followed_by"
    ],  
    "screen_name": "twitter"
}
*/
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    [DebuggerDisplay("{Name}:{string.Join(\",\", Connections)}")]
    public class TwitterFriendshipLookup : PropertyChangedBase, ITwitterModel
    {
        private string _name;
        private int _id;
        private ICollection<string> _connections;
        private string _screenName;

        [DataMember]
        public bool Following
        {
            get { return _connections.Contains("following"); }
        }

        [DataMember]
        public bool FollowingRequested
        {
            get { return _connections.Contains("following_requested"); }
        }

        [DataMember]
        public bool FollowedBy
        {
            get { return _connections.Contains("followed_by"); }
        }

        [DataMember]
        public bool None
        {
            get { return _connections.Contains("none"); }
        }

        public TwitterFriendshipLookup()
        {
            _connections = new List<string>(4);
        }
        
        [DataMember]
        public virtual string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;
                OnPropertyChanged("Name");
            }
        }

        [JsonProperty("connections")]
        [DataMember]
        public virtual ICollection<string> Connections
        {
            get { return _connections; }
            set
            {
                if (_connections == value)
                {
                    return;
                }
                _connections = value;
                OnPropertyChanged("Connections");
            }
        }

        [JsonProperty("id")]
        [DataMember]
        public virtual int Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                OnPropertyChanged("Id");
            }
        }

        [JsonProperty("screen_name")]
        [DataMember]
        public virtual string ScreenName
        {
            get { return _screenName; }
            set
            {
                if (_screenName == value)
                {
                    return;
                }

                _screenName = value;
                OnPropertyChanged("ScreenName");
            }
        }

        [DataMember]
        public virtual string RawSource { get; set; }
    }
}