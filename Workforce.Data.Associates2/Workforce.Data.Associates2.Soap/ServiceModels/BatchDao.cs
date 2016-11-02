using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Workforce.Data.Associates2.Soap.ServiceModels
{
    /// <summary>
    ///  This class defines the Batch Data Access Object and it's properties
    /// </summary>
    [DataContract]
    public class BatchDao
    {
        [DataMember]
        public int BatchID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Instructor { get; set; }

        [DataMember]
        public string Section { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }
    }
}