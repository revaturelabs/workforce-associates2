using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workforce.Data.Associates2.Domain;
using Workforce.Data.Associates2.Soap.ServiceModels;

namespace Workforce.Data.Associates2.Soap.Validators
{
  public class AddressVal : CoreValidator
  {

    public bool Validate(Address a)
    {
      if(StringValidate(a.City, 100) &&
        StringValidate(a.State, 20) &&
        StringValidate(a.Country, 100) &&
        StringValidate(a.zipcode, 20) &&
        StringValidate(a.address1, 200)&&
        StringValidate(a.address2, 200) 
        )
      {
        return true;
      }
        return false;
    }
    public bool Validate(AddressDao a)
    {
      if (StringValidate(a.City, 100) &&
        StringValidate(a.State, 20) &&
        StringValidate(a.Country, 100) &&
        StringValidate(a.Zipcode, 20) &&
        StringValidate(a.Address1, 200) &&
        StringValidate(a.Address2, 200)
        )
      {
        return true;
      }
      return false;
    }
  }
}