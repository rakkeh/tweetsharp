using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using TweetSharp.Helpers;

namespace TweetSharp
{
    [DataContract]
    [DebuggerDisplay("{User.ScreenName}: {Text}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterStatus : PropertyChangedBase,
                                 IComparable<TwitterStatus>,
                                 IEquatable<TwitterStatus>,
                                 ITwitterModel, 
                                 ITweetable
    {
        private DateTime _createdDate;
        private long _id;
        private string _idStr;
        private string _inReplyToScreenName;
        private long? _inReplyToStatusId;
        private long? _inReplyToUserId;
        private bool _isFavorited;
        private bool _isTruncated;
        private string _source;
        private string _text;
        private TwitterUser _user;
        private TwitterStatus _retweetedStatus;
        private TwitterGeoLocation _location;
        private string _language;
        private TwitterEntities _entities;
        private bool? _isPossiblySensitive;
        private TwitterPlace _place;
        private int _retweetCount;

        [DataMember]
        public virtual long Id
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

        [JsonProperty("id_str")]
        [DataMember]
        public virtual string IdStr
        {
            get { return _idStr; }
            set
            {
                if (_idStr == value)
                {
                    return;
                }

                _idStr = value;
                OnPropertyChanged("IdStr");
            }
        }

        [DataMember]
        public virtual long? InReplyToUserId
        {
            get { return _inReplyToUserId; }
            set
            {
                if (_inReplyToUserId == value)
                {
                    return;
                }

                _inReplyToUserId = value;
                OnPropertyChanged("InReplyToUserId");
            }
        }

        [DataMember]
        public virtual long? InReplyToStatusId
        {
            get { return _inReplyToStatusId; }
            set
            {
                if (_inReplyToStatusId == value)
                {
                    return;
                }

                _inReplyToStatusId = value;
                OnPropertyChanged("InReplyToStatusId");
            }
        }

        [DataMember]
        public virtual string InReplyToScreenName
        {
            get { return _inReplyToScreenName; }
            set
            {
                if (_inReplyToScreenName == value)
                {
                    return;
                }

                _inReplyToScreenName = value;
                OnPropertyChanged("InReplyToScreenName");
            }
        }

        [JsonProperty("truncated")]
        [DataMember]
        public virtual bool IsTruncated
        {
            get { return _isTruncated; }
            set
            {
                if (_isTruncated == value)
                {
                    return;
                }

                _isTruncated = value;
                OnPropertyChanged("IsTruncated");
            }
        }

        [JsonProperty("favorited")]
        [DataMember]
        public virtual bool IsFavorited
        {
            get { return _isFavorited; }
            set
            {
                if (_isFavorited == value)
                {
                    return;
                }

                _isFavorited = value;
                OnPropertyChanged("IsFavorited");
            }
        }

        [JsonProperty("retweet_count")]
        [DataMember]
        public virtual int RetweetCount
        {
            get
            {
                return _retweetCount;
            }
            set
            {
                if (_retweetCount == value)
                {
                    return;
                }

                _retweetCount = value;
                OnPropertyChanged("RetweetCount");
            }
        }

        [DataMember]
        public virtual string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                {
                    return;
                }

                _text = value;
                _textAsHtml = null;
                _textDecoded = null;
                OnPropertyChanged("Text");
            }
        }

        private string _textAsHtml;

                [DataMember]
        public virtual string TextAsHtml
        {
            get
            {
                return (_textAsHtml ?? (_textAsHtml = this.ParseTextWithEntities()));
            }
            set
            {
                _textAsHtml = value;
                this.OnPropertyChanged("TextAsHtml");
            }
        }

        private string _textDecoded;

        [DataMember]
        public virtual string TextDecoded
        {
            get
            {
                if (string.IsNullOrEmpty(Text))
                {
                    return Text;
                }

                throw new NotImplementedException();
                //return _textDecoded ?? (_textDecoded = System.Net.Http.HtmlDecode(Text));
                //return _textDecoded ?? (_textDecoded = System.Windows.Browser.HttpUtility.HtmlDecode(Text));
                //return _textDecoded ?? (_textDecoded = System.Net.HttpUtility.HtmlDecode(Text));
            }
            set
            {
                _textDecoded = value;
                OnPropertyChanged("TextDecoded");
            }
        }

        public ITweeter Author
        {
            get { return User; }
        }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Source
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

        [DataMember]
        public virtual TwitterUser User
        {
            get { return _user; }
            set
            {
                if (_user == value)
                {
                    return;
                }

                _user = value;
                OnPropertyChanged("TwitterUser");
            }
        }

        [DataMember]
        public virtual TwitterStatus RetweetedStatus
        {
            get { return _retweetedStatus; }
            set
            {
                if (_retweetedStatus == value)
                {
                    return;
                }

                _retweetedStatus = value;
                OnPropertyChanged("RetweetedStatus");
            }
        }

        [JsonProperty("created_at")]
        [DataMember]
        public virtual DateTime CreatedDate
        {
            get { return _createdDate; }
            set
            {
                if (_createdDate == value)
                {
                    return;
                }

                _createdDate = value;
                OnPropertyChanged("CreatedDate");
            }
        }

        [JsonProperty("geo")]
        [DataMember]
        public virtual TwitterGeoLocation Location
        {
            get { return _location; }
            set
            {
                if (_location == value)
                {
                    return;
                }

                _location = value;
                OnPropertyChanged("Location");
            }
        }


        [JsonProperty("lang")]
        [DataMember]
        public virtual string Language
        {
            get { return _language; }
            set
            {
                if (_language == value)
                {
                    return;
                }

                _language = value;
                OnPropertyChanged("Language");
            }
        }

        [DataMember]
        public virtual TwitterEntities Entities
        {
            get { return _entities; }
            set
            {
                if (_entities == value)
                {
                    return;
                }

                _entities = value;
                OnPropertyChanged("Entities");
            }
        }

        [JsonProperty("possibly_sensitive")]
        [DataMember]
        public virtual bool? IsPossiblySensitive
        {
            get { return _isPossiblySensitive; }
            set
            {
                if (_isPossiblySensitive == value)
                {
                    return;
                }

                _isPossiblySensitive = value;
                OnPropertyChanged("IsPossiblySensitive");
            }
        }

        [DataMember]
        public virtual TwitterPlace Place
        {
            get { return _place; }
            set
            {
                if (_place == value)
                {
                    return;
                }

                _place = value;
                OnPropertyChanged("Place");
            }
        }

        [DataMember]
        public virtual string RawSource { get; set; }

        #region IComparable<TwitterStatus> Members

        public int CompareTo(TwitterStatus other)
        {
            return other.Id == Id ? 0 : other.Id > Id ? -1 : 1;
        }

        #endregion

        #region IEquatable<TwitterStatus> Members

        public bool Equals(TwitterStatus status)
        {
            if (ReferenceEquals(null, status))
            {
                return false;
            }
            if (ReferenceEquals(this, status))
            {
                return true;
            }
            return status.Id == Id;
        }

        #endregion

        public override bool Equals(object status)
        {
            if (ReferenceEquals(null, status))
            {
                return false;
            }
            if (ReferenceEquals(this, status))
            {
                return true;
            }
            return status.GetType() == typeof (TwitterStatus) && Equals((TwitterStatus) status);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(TwitterStatus left, TwitterStatus right)
        {
            return Equals(left, right);
        }
        
        public static bool operator !=(TwitterStatus left, TwitterStatus right)
        {
            return !Equals(left, right);
        }
    }
}