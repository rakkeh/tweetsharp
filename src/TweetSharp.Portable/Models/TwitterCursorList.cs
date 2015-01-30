using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TweetSharp
{
    /// <summary>
    /// A generic collection that also contains any cursor data necessary for paging
    /// using Twitter's cursor feature.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class TwitterCursorList<T> : List<T>, ICursored
    {
        [DataMember]
        public virtual long? NextCursor { get; set; }

        [DataMember]
        public virtual long? PreviousCursor { get; set; }

        public TwitterCursorList(IEnumerable<T> collection) : base(collection)
        {

        }

        public TwitterCursorList(IEnumerable collection)
        {
            foreach(var item in collection)
            {
                Add((T)item);
            }
        }
    }
}