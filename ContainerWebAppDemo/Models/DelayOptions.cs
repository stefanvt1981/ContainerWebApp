using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ContainerWebAppDemo.Models
{
    [DataContract]
    public class DelayOptions 
    {
        [DataMember]
        public bool UseDelay { get; set; } = false;
        [DataMember]
        public int DelayInMilliseconds { get; set; }
    }
}
