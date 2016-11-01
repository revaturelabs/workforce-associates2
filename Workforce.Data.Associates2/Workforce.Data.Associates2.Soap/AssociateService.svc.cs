using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Workforce.Data.Associates2.Domain;

namespace Workforce.Data.Associates2.Soap
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FeliceService" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select FeliceService.svc or FeliceService.svc.cs at the Solution Explorer and start debugging.
  public class FeliceService : IFeliceService
  {
    private readonly AccessHelper ac = new AccessHelper();
    private readonly EfMapper emap = new EfMapper();

    AddressVal addressVal = new AddressVal();
    AssociateVal associateVal = new AssociateVal();
    AssociateAddressVal associateAddressVal = new AssociateAddressVal();
    BatchVal batchVal = new BatchVal();
    GenderVal genderVal = new GenderVal();
    InstructorVal instructorVal = new InstructorVal();


    #region GETS
    public List<AssociateDao> GetAssociates()
    {
      var associate = new List<AssociateDao>();
      var dataassociate = ac.GetAssociates();

      foreach (var item in dataassociate)
      {
        associate.Add(emap.MapToService(item));
      }

      return associate;
    }


    public List<AddressDao> GetAddress()
    {
      var address = new List<AddressDao>();
      var dataaddress = ac.GetAddress();

      foreach (var item in dataaddress)
      {
        address.Add(emap.MapToService(item));
      }

      return address;
    }



    public List<AssociateAddressDao> GetAssociateAddress()
    {
      var assocaddress = new List<AssociateAddressDao>();
      var dataassocaddress = ac.GetAssociateAddress();

      foreach (var item in dataassocaddress)
      {
        assocaddress.Add(emap.MapToService(item));
      }

      return assocaddress;
    }


    public List<BatchDao> GetBatches()
    {
      var batch = new List<BatchDao>();
      var databatch = ac.GetBatch();

      foreach (var item in databatch)
      {
        batch.Add(emap.MapToService(item));
      }

      return batch;
    }

    public List<GenderDao> GetGender()
    {
      var gender = new List<GenderDao>();
      var datagender = ac.GetGender();

      foreach (var item in datagender)
      {
        gender.Add(emap.MapToService(item));
      }

      return gender;
    }


    public List<InstructorDao> GetInstructor()
    {
      var instructor = new List<InstructorDao>();
      var datainstructor = ac.GetInstructor();

      foreach (var item in datainstructor)
      {
        instructor.Add(emap.MapToService(item));
      }

      return instructor;
    }
    #endregion


    #region INSERTS
    public bool InsertAddress(AddressDao newaddress)
    {
      try
      {
        if (addressVal.Validate(newaddress))
        {
          ac.InsertAddress(emap.MapToData(newaddress));
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }


    public bool InsertAssociate(AssociateDao newassociate)
    {
      try
      {
        if (associateVal.Validate(newassociate))
        {
          ac.InsertAssociate(emap.MapToData(newassociate));
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }


    public bool InsertAssociateAddress(AssociateAddressDao newassocaddress)
    {
      try
      {
        if (associateAddressVal.Validate(newassocaddress))
        {
          ac.InsertAssociateAddress(emap.MapToData(newassocaddress));
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }


    public bool InsertBatch(BatchDao newbatch)
    {
      try
      {
        if (batchVal.Validate(newbatch))
        {
          ac.InsertBatch(emap.MapToData(newbatch));
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool InsertGender(GenderDao newgender)
    {
      try
      {
        if (genderVal.Validate(newgender))
        {
          ac.InsertGender(emap.MapToData(newgender));
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }


    public bool InsertInstructor(InstructorDao newinstructor)
    {
      try
      {
        if (instructorVal.Validate(newinstructor))
        {
          ac.InsertInstructor(emap.MapToData(newinstructor));
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    #endregion


    #region UPDATES
    public bool UpdateAddress(AddressDao address)
    {
      try
      {
        if (addressVal.Validate(address))
        {
          return (ac.UpdateAddress(emap.MapToData(address)));
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }


    public bool UpdateAssociateAddress(AssociateAddressDao assocadd)
    {
      try
      {
        if (associateAddressVal.Validate(assocadd))
        {
          return (ac.UpdateAssociateAddress(emap.MapToData(assocadd)));
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }


    public bool UpdateAssociate(AssociateDao assoc)
    {
      try
      {
        if (associateVal.Validate(assoc))
        {
          return (ac.UpdateAssociate(emap.MapToData(assoc)));
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool UpdateBatch(BatchDao batch)
    {
      try
      {
        if (batchVal.Validate(batch))
        {
          return (ac.UpdateBatch(emap.MapToData(batch)));
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }


    public bool UpdateGender(GenderDao gender)
    {
      try
      {
        if (genderVal.Validate(gender))
        {
          return (ac.UpdateGender(emap.MapToData(gender)));
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }


    public bool UpdateInstructor(InstructorDao instructor)
    {
      try
      {
        if (instructorVal.Validate(instructor))
        {
          return (ac.UpdateInstructor(emap.MapToData(instructor)));
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    #endregion

    #region DELETES

    public bool DeleteAddress(AddressDao address)
    {
      try
      {
        return (ac.DeleteAddress(emap.MapToData(address)));

      }
      catch (Exception)
      {
        return false;
      }
    }


    public bool DeleteAssociateAddress(AssociateAddressDao assocadd)
    {
      try
      {
        return (ac.DeleteAssociateAddress(emap.MapToData(assocadd)));

      }
      catch (Exception)
      {
        return false;
      }
    }



    public bool DeleteAssociate(AssociateDao assoc)
    {
      try
      {
        return (ac.DeleteAssociate(emap.MapToData(assoc)));

      }
      catch (Exception)
      {
        return false;
      }
    }


    public bool DeleteBatch(BatchDao batch)
    {
      try
      {
        return (ac.DeleteBatch(emap.MapToData(batch)));

      }
      catch (Exception)
      {
        return false;
      }
    }



    public bool DeleteGender(GenderDao gender)
    {
      try
      {
        return (ac.DeleteGender(emap.MapToData(gender)));

      }
      catch (Exception)
      {
        return false;
      }
    }



    public bool DeleteInstructor(InstructorDao instructor)
    {
      try
      {
        return (ac.DeleteInstructor(emap.MapToData(instructor)));

      }
      catch (Exception)
      {
        return false;
      }
    }


    #endregion
  }
}
