using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterLocalTrends : TwitterTrends
    {
        private DateTime _createdDate;
        private IEnumerable<WhereOnEarthLocation> _locations;

        [DataMember]
        [JsonProperty("CreatedDate")]
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

        [DataMember]
        public virtual IEnumerable<WhereOnEarthLocation> Locations
        {
            get { return _locations; }
            set
            {
                if (_locations == value)
                {
                    return;
                }

                _locations = value;
                OnPropertyChanged("Locations");
            }
        }

        public TwitterLocalTrends()
        {
            Initialize();
        }

        private void Initialize()
        {
            Locations = new List<WhereOnEarthLocation>(0);
        }
    }
}