using System;
using Newtonsoft.Json;

namespace TweetSharp
{
    public class TwitterRateLimitResourceConverter : TwitterConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            var result = new TwitterRateLimitStatusSummary();
            reader.Read();
            reader.Read();
            reader.Read();
            result.AccessToken = reader.ReadAsString(); // access_token
            return result;
        }

        public override bool CanConvert(Type objectType)
        {
            var t = (IsNullableType(objectType))
                ? Nullable.GetUnderlyingType(objectType)
                : objectType;

            return typeof(TwitterRateLimitStatusSummary).IsAssignableFrom(t);
        }
    }
}