using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    // https://dev.twitter.com/docs/tweet-entities
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterEntities : IEnumerable<TwitterEntity>
    {
        [JsonProperty("user_mentions")]
        [DataMember]
        public virtual IList<TwitterMention> Mentions { get; set; }
        
        [JsonProperty("hashtags")]
        [DataMember]
        public virtual IList<TwitterHashTag> HashTags { get; set; }
      
        [JsonProperty("urls")]
        [DataMember]
        public virtual IList<TwitterUrl> Urls { get; set; }

        [JsonProperty("media")]
        [DataMember]
        public virtual IList<TwitterMedia> Media { get; set; }

        public TwitterEntities()
        {
            Initialize();
        }

        private void Initialize()
        {
            Mentions = new List<TwitterMention>(0);
            HashTags = new List<TwitterHashTag>(0);
            Urls = new List<TwitterUrl>(0);
            Media = new List<TwitterMedia>(0);
        }

        public IEnumerable<TwitterEntity> Coalesce()
        {
            var entities = new List<TwitterEntity>(Mentions.Count() + HashTags.Count() + Urls.Count() + Media.Count());
            entities.AddRange(Mentions);
            entities.AddRange(HashTags);
            entities.AddRange(Urls);
            entities.AddRange(Media);
            entities.Sort();
            return entities;
        }

        public IEnumerator<TwitterEntity> GetEnumerator()
        {
            return Coalesce().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
    [DebuggerDisplay("@{ScreenName}")]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterMention : TwitterEntity
    {
        [JsonProperty("id")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual long Id { get; set; }

        [JsonProperty("screen_name")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string ScreenName { get; set; }

        [JsonProperty("name")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Name { get; set; }

        public TwitterMention()
        {
            EntityType = TwitterEntityType.Mention;
        }
    }

#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
    [DebuggerDisplay("#{Text}")]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterHashTag : TwitterEntity
    {
        [JsonProperty("text")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Text { get; set; }

        public TwitterHashTag()
        {
            Initialize();
        }

        private void Initialize()
        {
            EntityType = TwitterEntityType.HashTag;
        }
    }

#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
    [DebuggerDisplay("{MediaType}:{MediaUrl}")]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterMedia : TwitterEntity
    {
        [JsonProperty("id")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual long Id { get; set; }

        [JsonProperty("id_str")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string IdAsString { get; set; }

        [JsonProperty("media_url")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string MediaUrl { get; set; }

        [JsonProperty("media_url_https")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string MediaUrlHttps { get; set; }

        [JsonProperty("url")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Url { get; set; }

        [JsonProperty("display_url")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string DisplayUrl { get; set; }

        [JsonProperty("expanded_url")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string ExpandedUrl { get; set; }

        [JsonProperty("type")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterMediaType MediaType { get; set; }

        [JsonProperty("sizes")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterMediaSizes Sizes { get; set; } 

        public TwitterMedia()
        {
            Initialize();
        }

        private void Initialize()
        {
            EntityType = TwitterEntityType.Media;
        }
    }

#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterMediaSizes : IEnumerable<TwitterMediaSize>
    {
        [JsonProperty("thumb")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterMediaSize Thumb { get; set; }

        [JsonProperty("small")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterMediaSize Small { get; set; }

        [JsonProperty("medium")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterMediaSize Medium { get; set; }

        [JsonProperty("large")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterMediaSize Large { get; set; }

        public IEnumerator<TwitterMediaSize> GetEnumerator()
        {
            return Coalesce().GetEnumerator();
        }

        private IEnumerable<TwitterMediaSize> Coalesce()
        {
            var sizes = new List<TwitterMediaSize>();
            if(Thumb != null)
            {
                sizes.Add(Thumb);
            }
            if(Small != null)
            {
                sizes.Add(Small);
            }
            if(Medium != null)
            {
                sizes.Add(Medium);
            }
            if(Large != null)
            {
                sizes.Add(Large);
            }
            return sizes;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

#if !SILVERLIGHT
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterMediaSize
    {
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Resize { get; set; }

        [JsonProperty("w")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual int Width { get; set; }

        [JsonProperty("h")]
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual int Height { get; set; }
    }
}
