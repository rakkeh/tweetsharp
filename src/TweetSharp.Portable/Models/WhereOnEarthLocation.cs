using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using TweetSharp.Model;

namespace TweetSharp
{
    // {
    //     "url":"http://where.yahooapis.com/v1/place/23424900",
    //     "woeid":23424900,
    //     "placeType":{"code":12,"name":"Country"},
    //     "countryCode":"MX",
    //     "name":"Mexico",
    //     "country":"Mexico" }

    /// <summary>
    /// Represents a location in the Yahoo! WOE specification.
    /// </summary>
    /// <seealso>"http://developer.yahoo.com/geo/geoplanet/"</seealso>
    [DataContract]
    [DebuggerDisplay("{WoeId}: {Name}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class WhereOnEarthLocation : PropertyChangedBase, ITwitterModel 
    {
        private long _woeId;
        private string _url;
        private string _name;
        private string _countryCode;
        private string _country;
        private WhereOnEarthPlaceType _placeType;

        [DataMember]
        [JsonProperty("woeid")]
        public virtual long WoeId
        {
            get { return _woeId; }
            set
            {
                if (_woeId == value)
                {
                    return;
                }

                _woeId = value;
                OnPropertyChanged("WoeId");
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
        [JsonProperty("placeType")]
        public virtual WhereOnEarthPlaceType PlaceType
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
        [JsonProperty("countryCode")]
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
        public virtual string RawSource { get; set; }
    }
}