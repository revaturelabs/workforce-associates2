using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Workforce.Data.Associates2.Soap.ServiceModels
{
    /// <summary>
    ///  This class defines the Instructor Data Access Object and it's properties
    /// </summary>

    [DataContract]
    public class InstructorDao
    {
        [DataMember]
        public int InstructorId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}