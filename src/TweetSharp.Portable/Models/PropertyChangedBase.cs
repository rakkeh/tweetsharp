using System.ComponentModel;
using System.Runtime.Serialization;

namespace TweetSharp
{
    [DataContract]
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public virtual event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}