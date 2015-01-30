using System.Runtime.Serialization;

namespace TweetSharp
{
    [DataContract]
    public enum TwitterListMode
    {
        Public,
        Private
    }
}