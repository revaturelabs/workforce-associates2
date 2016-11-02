using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Workforce.Data.Associates2.Soap.ServiceModels
{
    [DataContract]
    public class AssociateAddressDao
    {
        [DataMember]
        public int AssociateAddressID { get; set; }

        [DataMember]
        public int AssociateID { get; set; }

        [DataMember]
        public int AddressID { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}