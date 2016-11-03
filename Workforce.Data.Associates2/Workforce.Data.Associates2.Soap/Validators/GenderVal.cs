using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workforce.Data.Associates2.Domain;
using Workforce.Data.Associates2.Soap.ServiceModels;

namespace Workforce.Data.Associates2.Soap.Validators
{
  public class GenderVal : CoreValidator
  {
    public bool Validate(Gender g)
    {
      if(PrimaryKeyValidate(g.GenderId) &&
        StringValidate(g.Name, 50))
      {
        return true;
      }
      return false;
    }
    public bool Validate(GenderDao g)
    {
      if (PrimaryKeyValidate(g.GenderID) &&
        StringValidate(g.Name, 50))
      {
        return true;
      }
      return false;
    }
  }
}