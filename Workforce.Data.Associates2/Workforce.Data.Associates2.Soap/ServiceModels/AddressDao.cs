using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Workforce.Data.Associates2.Soap.ServiceModels
{
    /// <summary>
    ///  This class defines the Address Data Access Object and it's properties
    /// </summary>
    
    [DataContract]
    public class AddressDao
    {
        [DataMember]
        public int AddressId { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string Zipcode { get; set; }

        [DataMember]
        public bool Primary { get; set; }

        [DataMember]
        public string Address1 { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}