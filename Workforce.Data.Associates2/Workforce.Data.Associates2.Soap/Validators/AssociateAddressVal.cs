using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workforce.Data.Associates2.Domain;
using Workforce.Data.Associates2.Soap.ServiceModels;

namespace Workforce.Data.Associates2.Soap.Validators
{
  public class AssociateAddressVal : CoreValidator
  {
    public bool Validate(AssociateAddress a)
    {
      if(PrimaryKeyValidate(a.AssociateAddressID) &&
         PrimaryKeyValidate(a.AddressID)&&
         PrimaryKeyValidate(a.AssociateID)
        )
      {
        return true;
      }
      return false;
    }
    public bool Validate(AssociateAddressDao a)
    {
      if (PrimaryKeyValidate(a.AssociateAddressID) &&
         PrimaryKeyValidate(a.AddressID) &&
         PrimaryKeyValidate(a.AssociateID)
        )
      {
        return true;
      }
      return false;
    }
  }
}