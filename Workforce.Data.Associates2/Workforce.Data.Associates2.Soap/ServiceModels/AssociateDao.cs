using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Workforce.Data.Associates2.Soap.ServiceModels
{
    /// <summary>
    /// This class defines the Associate Data Access Object and it's properties
    /// </summary>
    [DataContract]
    public class AssociateDao
    {
        [DataMember]
        public int AssociateID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public int GenderID { get; set; }

        [DataMember]
        public int BatchID { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime? DateOfBirth { get; set; }

        [DataMember]
        public bool HasCar { get; set; }

        [DataMember]
        public bool HasKeys { get; set; }

        [DataMember]
        public bool? IsComing { get; set; }

        [DataMember]
        public bool Active { get; set; }

    }
}