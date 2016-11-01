using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Workforce.Data.Associates2.Soap.ServiceModels
{
    /// <summary>
    ///  This class defines the Gender Data Access Object and it's properties
    /// </summary>

    [DataContract]
    public class GenderDao
    {
        [DataMember]
        public int GenderID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}