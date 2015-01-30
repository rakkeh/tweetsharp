using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterSleepTime : PropertyChangedBase,
                                    IComparable<TwitterSleepTime>,
                                    IEquatable<TwitterSleepTime>,
                                    ITwitterModel
    {
        private int _startTime;
        private int _endTime;
        private bool? _enabled;

        [DataMember]
        public virtual int StartTime
        {
            get { return _startTime; }
            set
            {
                if (_startTime == value)
                {
                    return;
                }

                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }

        [DataMember]
        public virtual int EndTime
        {
            get { return _endTime; }
            set
            {
                if (_endTime == value)
                {
                    return;
                }

                _endTime = value;
                OnPropertyChanged("EndTime");
            }
        }

        [DataMember]
        // This property is currently undocumented; it is a string to avoid breaking serialization
        public virtual bool? Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled == value)
                {
                    return;
                }

                _enabled = value;
                OnPropertyChanged("StartTime");
            }
        }

        public int CompareTo(TwitterSleepTime other)
        {
            return StartTime.CompareTo(other.StartTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (TwitterSleepTime)) return false;
            return Equals((TwitterSleepTime) obj);
        }

        public override int GetHashCode()
        {
            return (RawSource != null ? RawSource.GetHashCode() : 0);
        }

        public static bool operator ==(TwitterSleepTime left, TwitterSleepTime right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TwitterSleepTime left, TwitterSleepTime right)
        {
            return !Equals(left, right);
        }

        public bool Equals(TwitterSleepTime other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.RawSource, RawSource);
        }

        [DataMember]
        public virtual string RawSource { get; set; }
    }
}
