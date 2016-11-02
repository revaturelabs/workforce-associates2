using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workforce.Data.Associates2.Domain;
using Workforce.Data.Associates2.Soap.ServiceModels;

namespace Workforce.Data.Associates2.Soap.Validators
{
  public class AssociateVal : CoreValidator
  {
    public bool Validate(Associate a)
    {
      if(PrimaryKeyValidate(a.AssociateID) &&
        StringValidate(a.FirstName,100) &&
        StringValidate(a.LastName,100) &&
        IntValidate(a.GenderID) &&
        IntValidate(a.BatchID) &&
        StringValidate(a.PhoneNumber, 15) &&
        StringValidate(a.Email, 400))
      {
        return false;
      }
      return false;
    }
    public bool Validate(AssociateDao a)
    {
      if (PrimaryKeyValidate(a.AssociateID) &&
        StringValidate(a.FirstName, 100) &&
        StringValidate(a.LastName, 100) &&
        IntValidate(a.GenderID) &&
        IntValidate(a.BatchID) &&
        StringValidate(a.PhoneNumber, 15) &&
        StringValidate(a.Email, 400))
      {
        return true;
      }
      return false;
    }
  }
}