using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workforce.Data.Associates2.Domain;
using Workforce.Data.Associates2.Soap.ServiceModels;

namespace Workforce.Data.Associates2.Soap.Validators
{
  public class InstructorVal : CoreValidator
  {
    public bool Validate(Instructor i)
    {
      if(PrimaryKeyValidate(i.InstructorId) &&
         StringValidate(i.FirstName,100) &&
         StringValidate(i.LastName,100) 
        )
      {
        return true;
      }
      return false;
    }

    public bool Validate(InstructorDao i)
    {
      if (PrimaryKeyValidate(i.InstructorId) &&
         StringValidate(i.FirstName, 100) &&
         StringValidate(i.LastName, 100)
        )
      {
        return true;
      }
      return false;
    }
  }
}