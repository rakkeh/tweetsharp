using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp.Model
{
    /// <summary>
    /// Represents a place type for a <see cref="WhereOnEarthLocation" /> in the Yahoo! WOE specification.
    /// </summary>
    /// <seealso>http://developer.yahoo.com/geo/geoplanet/"</seealso>
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class WhereOnEarthPlaceType : PropertyChangedBase
    {
        private int _code;
        private string _name;

        [DataMember]
        [JsonProperty("code")]
        public virtual int Code
        {
            get { return _code; }
            set
            {
                if (_code == value)
                {
                    return;
                }

                _code = value;
                OnPropertyChanged("Code");
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
    }
}