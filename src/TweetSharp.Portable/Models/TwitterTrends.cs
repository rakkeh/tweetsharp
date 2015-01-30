using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterTrends : PropertyChangedBase, ITwitterModel, IEnumerable<TwitterTrend>
    {
        private List<TwitterTrend> _trends;

        [DataMember]
        public virtual List<TwitterTrend> Trends
        {
            get { return _trends; }
            set
            {
                if (_trends == value)
                {
                    return;
                }

                _trends = value;
                OnPropertyChanged("Trends");
            }
        }

        [DataMember]
        public virtual string RawSource { get; set; }

        public virtual IEnumerator<TwitterTrend> GetEnumerator()
        {
            return Trends.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TwitterTrends()
        {
            Initialize();
        }

        private void Initialize()
        {
            Trends = new List<TwitterTrend>(0);
        }
    }
}