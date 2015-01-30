using System.Runtime.Serialization;

namespace TweetSharp
{
    [DataContract]
    public enum TwitterPlaceType
    {
        City,
        Neighborhood,
        Country,
        Admin,
        POI
    }
}