using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workforce.Data.Associates2.Domain;
using Workforce.Data.Associates2.Soap.ServiceModels;


namespace Workforce.Data.Associates2.Soap.Validators
{
  public class BatchVal : CoreValidator
  {
    public bool Validate(Batch b)
    {
      if(PrimaryKeyValidate(b.BatchId) &&
        StringValidate(b.Name, 100) &&
        IntValidate(b.Instructor) 
        )
      {
        return true;
      }
      return false;
    }
    public bool Validate(BatchDao b)
    {
      if (PrimaryKeyValidate(b.BatchID) &&
        StringValidate(b.Name, 100) &&
        IntValidate(b.Instructor)
        )
      {
        return true;
      }
      return false;
    }
  }
}