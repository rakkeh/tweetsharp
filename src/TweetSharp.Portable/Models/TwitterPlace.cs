using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    [DataContract]
    [DebuggerDisplay("{FullName}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterPlace : PropertyChangedBase, 
                                IComparable<TwitterPlace>,
                                IEquatable<TwitterPlace>,
                                ITwitterModel
    {
        private string _id;
        private string _name;
        private string _fullName;
        private string _country;
        private string _countryCode;
        private string _url;
        private TwitterPlaceType _placeType;
        private IEnumerable<TwitterPlace> _containedWithin;

        [DataMember]
        public virtual string Id
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

        [DataMember]
        public virtual string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName == value)
                {
                    return;
                }

                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        [DataMember]
        public virtual string Country
        {
            get { return _country; }
            set
            {
                if (_country == value)
                {
                    return;
                }

                _country = value;
                OnPropertyChanged("Country");
            }
        }

        [DataMember]
        public virtual string CountryCode
        {
            get { return _countryCode; }
            set
            {
                if (_countryCode == value)
                {
                    return;
                }

                _countryCode = value;
                OnPropertyChanged("CountryCode");
            }
        }

        [DataMember]
        public virtual string Url
        {
            get { return _url; }
            set
            {
                if (_url == value)
                {
                    return;
                }

                _url = value;
                OnPropertyChanged("Url");
            }
        }

        [DataMember]
        public virtual TwitterPlaceType PlaceType
        {
            get { return _placeType; }
            set
            {
                if (_placeType == value)
                {
                    return;
                }

                _placeType = value;
                OnPropertyChanged("PlaceType");
            }
        }

        [DataMember]
        public virtual IEnumerable<TwitterPlace> ContainedWithin
        {
            get { return _containedWithin; }
            set
            {
                if (_containedWithin == value)
                {
                    return;
                }

                _containedWithin = value;
                OnPropertyChanged("ContainedWithin");
            }
        }

        [DataMember]
        public virtual string RawSource { get; set; }

        public int CompareTo(TwitterPlace other)
        {
            return Id.CompareTo(other.Id);
        }

        public bool Equals(TwitterPlace other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Equals(other._id, _id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof (TwitterPlace) && Equals((TwitterPlace) obj);
        }

        public override int GetHashCode()
        {
            return (_id != null ? _id.GetHashCode() : 0);
        }

        public static bool operator ==(TwitterPlace left, TwitterPlace right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TwitterPlace left, TwitterPlace right)
        {
            return !Equals(left, right);
        }
    }
}
