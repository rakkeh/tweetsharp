using System.Runtime.Serialization;

namespace TweetSharp
{
    [DataContract]
    public class TwitterGeoLocationSearch : TwitterGeoLocation
    {
        /// <summary>
        /// Radius type in Miles or Kilometers
        /// </summary>
        public enum RadiusType
        {
            Mi,
            Km
        }
        
        public TwitterGeoLocationSearch(double latitutde, double longitude, int radius, RadiusType unitOfMeasurement)
            : base(latitutde, longitude)
        {
            Radius = radius;
            UnitOfMeasurement = unitOfMeasurement;
        }

        [DataMember]
        public int Radius { get; set; }

        [DataMember]
        public RadiusType UnitOfMeasurement { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}{3}", Coordinates.Latitude, Coordinates.Longitude, Radius,
                                 UnitOfMeasurement.ToString().ToLower());
        }
    }
}