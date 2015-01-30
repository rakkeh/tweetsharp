using System.Runtime.Serialization;

namespace TweetSharp
{
    [DataContract]
    public enum TwitterEntityType
    {
        HashTag,
        Mention,
        Url,
        Media
    }
}