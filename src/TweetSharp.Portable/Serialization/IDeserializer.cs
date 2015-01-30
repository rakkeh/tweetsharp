using System;
using System.Net.Http;

namespace TweetSharp
{
    public interface IDeserializer
    {
        object Deserialize(HttpResponseMessage response, Type type);
        T Deserialize<T>(HttpResponseMessage response);
        dynamic DeserializeDynamic(HttpResponseMessage response);
    }
}