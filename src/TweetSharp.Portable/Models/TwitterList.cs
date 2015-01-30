using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    /*     
     <list>
        <id>2029636</id>
        <name>firemen</name>
        <full_name>@twitterapidocs/firemen</full_name>
        <slug>firemen</slug>
        <subscriber_count>0</subscriber_count>
        <member_count>0</member_count>
        <uri>/twitterapidocs/firemen</uri>
        <mode>public</mode>    
        <user/>
     </list>     
     */

    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterList : PropertyChangedBase, ITwitterModel
    {
        private long _id;
        private string _name;
        private string _fullName;
        private string _slug;
        private string _description;
        private int _subscriberCount;
        private int _memberCount;
        private string _uri;
        private string _mode;
        private TwitterUser _user;

        /// <summary>
        /// Gets or sets the ID of the list.
        /// </summary>
        /// <value>The list ID.</value>
        [DataMember]
        public virtual long Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Gets or sets the descriptive name of the list.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public virtual string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the full name of the list including the list owner.
        /// </summary>
        /// <value>The full name of the list.</value>
        [DataMember]
        public virtual string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName == value)
                {
                    return;
                }

                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        /// <summary>
        /// Gets or sets the user-supplied list description.
        /// </summary>
        /// <value>The list description.</value>
        [DataMember]
        public virtual string Description
        {
            get { return _description; }
            set
            {
                if (_description == value)
                {
                    return;
                }

                _description = value;
                OnPropertyChanged("Description");
            }
        }
        
        /// <summary>
        /// Gets or sets the list URL slug.
        /// </summary>
        /// <value>The list slug.</value>
        [DataMember]
        public virtual string Slug
        {
            get { return _slug; }
            set
            {
                if (_slug == value)
                {
                    return;
                }

                _slug = value;
                OnPropertyChanged("Slug");
            }
        }

        /// <summary>
        /// Gets or sets the subscriber count.
        /// A subscriber follows the list's updates.
        /// </summary>
        /// <value>The subscriber count.</value>
        [DataMember]
        public virtual int SubscriberCount
        {
            get { return _subscriberCount; }
            set
            {
                if (_subscriberCount == value)
                {
                    return;
                }

                _subscriberCount = value;
                OnPropertyChanged("SubscriberCount");
            }
        }

        /// <summary>
        /// Gets or sets the member count.
        /// A member's updates appear in the list.
        /// </summary>
        /// <value>The member count.</value>
        [DataMember]
        public virtual int MemberCount
        {
            get { return _memberCount; }
            set
            {
                if (_memberCount == value)
                {
                    return;
                }

                _memberCount = value;
                OnPropertyChanged("MemberCount");
            }
        }

        /// <summary>
        /// Gets or sets the URI of the list.
        /// </summary>
        /// <value>The URI of the list.</value>
        [DataMember]
        public virtual string Uri
        {
            get { return _uri; }
            set
            {
                if (_uri == value)
                {
                    return;
                }

                _uri = value;
                OnPropertyChanged("Uri");
            }
        }

        /// <summary>
        /// Gets or sets the mode.
        /// The list can be "public", visible to everyone,
        /// or "private", visible only to the authenticating user.
        /// </summary>
        /// <value>The mode.</value>
        [DataMember]
        public virtual string Mode
        {
            get { return _mode; }
            set
            {
                if (_mode == value)
                {
                    return;
                }

                _mode = value;
                OnPropertyChanged("Mode");
            }
        }

        /// <summary>
        /// Gets or sets the user who created the list.
        /// </summary>
        /// <value>The user.</value>
        [DataMember]
        public virtual TwitterUser User
        {
            get { return _user; }
            set
            {
                if (_user == value)
                {
                    return;
                }

                _user = value;
                OnPropertyChanged("User");
            }
        }

        [DataMember]
        public virtual string RawSource { get; set; }
    }
}