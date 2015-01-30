using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Threading;


namespace TweetSharp
{
    /// <summary>
    /// Represents a normalized date from the Twitter API. 
    /// </summary>
    [DataContract]
    public class TwitterDateTime : ITwitterModel
    {
        private static readonly object Lock = new object();
        private static readonly IDictionary<string, string> Map = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the Twitter-based date format.
        /// </summary>
        /// <value>The format.</value>
        [DataMember]
        public virtual TwitterDateFormat Format { get; private set; }

        /// <summary>
        /// Gets or sets the actual date time.
        /// </summary>
        /// <value>The date time.</value>
        [DataMember]
        public virtual DateTime DateTime { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TwitterDateTime"/> class.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="format">The format.</param>
        public TwitterDateTime(DateTime dateTime, TwitterDateFormat format)
        {
            Format = format;
            DateTime = dateTime;
        }

        /// <summary>
        /// Converts from date time.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public static string ConvertFromDateTime(DateTime input, TwitterDateFormat format)
        {
            EnsureDateFormatsAreMapped();
            var name = Enum.GetName(typeof(TwitterDateFormat), format);
            GetReadLockOnMap();
            if (name == null) return null;

            var value = Map[name];
            ReleaseReadLockOnMap();
            value = value.Replace(" zzzzz", " +0000");

            var converted = input.ToString(value, CultureInfo.InvariantCulture);
            return converted;
        }

        /// <summary>
        /// Converts to date time.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(string input)
        {
            EnsureDateFormatsAreMapped();
            GetReadLockOnMap();
            var formats = Map.Values;
            ReleaseReadLockOnMap();
            foreach (var format in formats)
            {
                DateTime date;
                if (DateTime.TryParseExact(input, format,
                                           CultureInfo.InvariantCulture,
                                           DateTimeStyles.AdjustToUniversal, out date))
                {
                    return date;
                }
            }

            return default(DateTime);
        }

        /// <summary>
        /// Converts to twitter date time.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static TwitterDateTime ConvertToTwitterDateTime(string input)
        {
            EnsureDateFormatsAreMapped();
            GetReadLockOnMap();
            try
            {
                foreach (var format in Map)
                {
                    DateTime date;
                    if (DateTime.TryParseExact(input, format.Value,
                                               CultureInfo.InvariantCulture,
                                               DateTimeStyles.AdjustToUniversal, out date))
                    {
                        var kind = Enum.Parse(typeof (TwitterDateFormat), format.Key, true);
                        return new TwitterDateTime(date, (TwitterDateFormat) kind);
                    }
                }

                return default(TwitterDateTime);
            }
            finally
            {
                ReleaseReadLockOnMap();
            }
        }

        private static void EnsureDateFormatsAreMapped()
        {
            var type = typeof (TwitterDateFormat);
            var names = Enum.GetNames(type);
            GetReadLockOnMap();
            try
            {
                foreach (var name in names)
                {
                    if (Map.ContainsKey(name))
                    {
                        continue;
                    }
                    GetWriteLockOnMap();
                    try
                    {
                        var fi = typeof (TwitterDateFormat).GetField(name);
                        var attributes = fi.GetCustomAttributes(typeof (DescriptionAttribute), false);
                        var format = (DescriptionAttribute) attributes[0];

                        Map.Add(name, format.Description);
                    }
                    finally
                    {
                        ReleaseWriteLockOnMap();
                    }
                }
            }
            finally
            {
                ReleaseReadLockOnMap();
            }
        }


        private static void GetReadLockOnMap()
        {
            Monitor.Enter(Lock);
        }

        private static void ReleaseReadLockOnMap()
        {
            Monitor.Exit(Lock);
        }

        private static void GetWriteLockOnMap()
        {
            // Already have exclusive access
        }

        private static void ReleaseWriteLockOnMap()
        {
            // Will exit when we give up read lock
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return ConvertFromDateTime(DateTime, Format);
        }

        [DataMember]
        public virtual string RawSource { get; set; }
    }
}