using System.Runtime.Serialization;

namespace TweetSharp
{
    [DataContract]
    public enum TwitterSearchResultType
    {
        Mixed,
        Recent,
        Popular
    }
}