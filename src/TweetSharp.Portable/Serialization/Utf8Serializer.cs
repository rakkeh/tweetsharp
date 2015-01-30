using System.Text;

namespace TweetSharp
{
    public abstract class Utf8Serializer
    {
        public virtual Encoding ContentEncoding
        {
            get { return Encoding.UTF8; }
        }
    }
}