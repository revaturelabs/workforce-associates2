using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Data.Associates2.Domain
{
  /// <summary>
  /// This AccessHelper will provide the Get, Inserts, Updates and Deletes for all Project
  /// Felice tables
  /// </summary>
  public class AccessHelper
  {
    private readonly ProjectFeliceDB_TestEntities db = new ProjectFeliceDB_TestEntities();

    #region FeliceGets
    /// <summary>
    /// Gets a list of Associates
    /// </summary>
    /// <returns>A list of Associates</returns>
    public List<Associate> GetAssociates()
    {
      return db.Associate.ToList();
    }

    /// <summary>
    /// Return a list of Addresses
    /// </summary>
    /// <returns></returns>
    public List<Address> GetAddress()
    {
      return db.Address.ToList();
    }

    /// <summary>
    /// Return a list of AssociateAddress
    /// </summary>
    /// <returns></returns>
    public List<AssociateAddress> GetAssociateAddress()
    {
      return db.AssociateAddress.ToList();
    }

    /// <summary>
    /// Returns a list of Batches
    /// </summary>
    /// <returns></returns>
    public List<Batch> GetBatch()
    {
      return db.Batch.ToList();
    }

    /// <summary>
    /// Returns a list of Gender
    /// </summary>
    /// <returns></returns>
    public List<Gender> GetGender()
    {
      return db.Gender.ToList();
    }

    /// <summary>
    /// Returns a list of Instructor
    /// </summary>
    /// <returns></returns>
    public List<Instructor> GetInstructor()
    {
      return db.Instructor.ToList();
    }
    #endregion
    #region FeliceInserts
    /// <summary>
    /// Inserts Address into the database
    /// </summary>
    /// <param name="ad"></param>
    /// <returns></returns>
    public bool InsertAddress(Address ad)
    {
      ad.Active = true;
      try
      {
        db.Address.Add(ad);
        int columnsAffected = db.SaveChanges();
        if (columnsAffected == 0)
        {
          return false;
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Inserts Associate into the database
    /// </summary>
    /// <param name="asso"></param>
    /// <returns></returns>
    public bool InsertAssociate(Associate asso)
    {
      asso.Active = true;
      try
      {
        db.Associate.Add(asso);
        int columnsAffected = db.SaveChanges();
        if (columnsAffected == 0)
        {
          return false;
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Inserts AssociateAddress into the database
    /// </summary>
    /// <param name="assad"></param>
    /// <returns></returns>
    public bool InsertAssociateAddress(AssociateAddress assad)
    {
      assad.Active = true;
      try
      {
        db.AssociateAddress.Add(assad);
        int columnsAffected = db.SaveChanges();
        if (columnsAffected == 0)
        {
          return false;
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Inserts Batch into the database
    /// </summary>
    /// <param name="bat"></param>
    /// <returns></returns>
    public bool InsertBatch(Batch bat)
    {
      bat.Active = true;
      try
      {
        db.Batch.Add(bat);
        int columnsAffected = db.SaveChanges();
        if (columnsAffected == 0)
        {
          return false;
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Inserts Gender into the database
    /// </summary>
    /// <param name="gen"></param>
    /// <returns></returns>
    public bool InsertGender(Gender gen)
    {
      gen.Active = true;
      try
      {
        db.Gender.Add(gen);
        int columnsAffected = db.SaveChanges();
        if (columnsAffected == 0)
        {
          return false;
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Inserts an Instructor into the database
    /// </summary>
    /// <param name="inst"></param>
    /// <returns></returns>
    public bool InsertInstructor(Instructor inst)
    {
      inst.Active = true;
      try
      {
        db.Instructor.Add(inst);
        int columnsAffected = db.SaveChanges();
        if (columnsAffected == 0)
        {
          return false;
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
    #endregion
    #region FeliceUpdates

    /// <summary>
    /// Will update the Address in the database
    /// </summary>
    /// <param name="addr"></param>
    /// <returns></returns>
    public bool UpdateAddress(Address addr)
    {
      try
      {
        var oldaddr = db.Address.FirstOrDefault(a => a.AddressId == addr.AddressId);
        if (oldaddr != null)
        {
          db.Entry(oldaddr).CurrentValues.SetValues(addr);
          int columnsAffected = db.SaveChanges();
          if (columnsAffected == 0)
          {
            return false;
          }
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will update the Associate in the database
    /// </summary>
    /// <param name="asso"></param>
    /// <returns></returns>
    public bool UpdateAssociate(Associate asso)
    {
      try
      {
        var oldasso = db.Associate.FirstOrDefault(a => a.AssociateID == asso.AssociateID);
        if (oldasso != null)
        {
          db.Entry(oldasso).CurrentValues.SetValues(asso);
          int columnsAffected = db.SaveChanges();
          if (columnsAffected == 0)
          {
            return false;
          }
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will update the AssociateAddress in the database
    /// </summary>
    /// <param name="assodr"></param>
    /// <returns></returns>
    public bool UpdateAssociateAddress(AssociateAddress assodr)
    {
      try
      {
        var oldasso = db.AssociateAddress.FirstOrDefault(a => a.AssociateID == assodr.AssociateAddressID);
        if (oldasso != null)
        {
          db.Entry(oldasso).CurrentValues.SetValues(assodr);
          int columnsAffected = db.SaveChanges();
          if (columnsAffected == 0)
          {
            return false;
          }
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will update the Batch in the database
    /// </summary>
    /// <param name="bat"></param>
    /// <returns></returns>
    public bool UpdateBatch(Batch bat)
    {
      try
      {
        var oldbatch = db.Batch.FirstOrDefault(b => b.BatchId == bat.BatchId);
        if (oldbatch != null)
        {
          db.Entry(oldbatch).CurrentValues.SetValues(bat);
          int columnsAffected = db.SaveChanges();
          if (columnsAffected == 0)
          {
            return false;
          }
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will update the Gender in the database
    /// </summary>
    /// <param name="gen"></param>
    /// <returns></returns>
    public bool UpdateGender(Gender gen)
    {
      try
      {
        var oldgender = db.Gender.FirstOrDefault(g => g.GenderId == gen.GenderId);
        if (oldgender != null)
        {
          db.Entry(oldgender).CurrentValues.SetValues(gen);
          int columnsAffected = db.SaveChanges();
          if (columnsAffected == 0)
          {
            return false;
          }
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will update the Instructor in the database
    /// </summary>
    /// <param name="inst"></param>
    /// <returns></returns>
    public bool UpdateInstructor(Instructor inst)
    {
      var oldinst = db.Instructor.FirstOrDefault(i => i.InstructorId == inst.InstructorId);
      if (oldinst != null)
      {
        db.Entry(oldinst).CurrentValues.SetValues(inst);
        int columnsAffected = db.SaveChanges();
        if (columnsAffected == 0)
        {
          return false;
        }
      }
      return true;
    }
    #endregion
    #region FeliceDeletes

    /// <summary>
    /// Will delete Address by setting Active bit
    /// </summary>
    /// <param name="addr"></param>
    /// <returns></returns>
    public bool DeleteAddress(Address addr)
    {
      try
      {
        var oldaddr = db.Address.FirstOrDefault(a => a.AddressId == addr.AddressId);
        if (oldaddr != null)
        {
          addr = oldaddr;
          addr.Active = false;
          db.Entry(oldaddr).CurrentValues.SetValues(addr);
          db.SaveChanges();
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will delete Associate by setting Active Bit
    /// </summary>
    /// <param name="asso"></param>
    /// <returns></returns>
    public bool DeleteAssociate(Associate asso)
    {
      try
      {
        var oldasso = db.Associate.FirstOrDefault(a => a.AssociateID == asso.AssociateID);
        if (oldasso != null)
        {
          asso = oldasso;
          asso.Active = false;
          db.Entry(oldasso).CurrentValues.SetValues(asso);
          db.SaveChanges();
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will deletes AssociateAddress by setting Active Bit
    /// </summary>
    /// <param name="assodr"></param>
    /// <returns></returns>
    public bool DeleteAssociateAddress(AssociateAddress assodr)
    {
      try
      {
        var oldasso = db.AssociateAddress.FirstOrDefault(a => a.AssociateID == assodr.AssociateAddressID);
        if (oldasso != null)
        {
          assodr = oldasso;
          assodr.Active = false;
          db.Entry(oldasso).CurrentValues.SetValues(assodr);
          db.SaveChanges();
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will delete Batch by setting Active bit
    /// </summary>
    /// <param name="bat"></param>
    /// <returns></returns>
    public bool DeleteBatch(Batch bat)
    {
      try
      {
        var oldbatch = db.Batch.FirstOrDefault(b => b.BatchId == bat.BatchId);
        if (oldbatch != null)
        {
          bat = oldbatch;
          bat.Active = false;
          db.Entry(oldbatch).CurrentValues.SetValues(bat);
          db.SaveChanges();
        }
        return true;
      }
      catch (DbEntityValidationException e)
      {
        foreach (var eve in e.EntityValidationErrors)
        {
          String error = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
              eve.Entry.Entity.GetType().Name, eve.Entry.State);
          foreach (var ve in eve.ValidationErrors)
          {
            String errorInside = String.Format("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                ve.PropertyName,
                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                ve.ErrorMessage);
          }
        }
        throw;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will delete Gender by setting Active bit
    /// </summary>
    /// <param name="gen"></param>
    /// <returns></returns>
    public bool DeleteGender(Gender gen)
    {
      try
      {
        var oldgender = db.Gender.FirstOrDefault(g => g.GenderId == gen.GenderId);
        if (oldgender != null)
        {
          gen = oldgender;
          gen.Active = false;
          db.Entry(oldgender).CurrentValues.SetValues(gen);
          db.SaveChanges();
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Will delete the Instructor by setting the Active bit
    /// </summary>
    /// <param name="inst"></param>
    /// <returns></returns>
    public bool DeleteInstructor(Instructor inst)
    {
      try
      {
        var oldinst = db.Instructor.FirstOrDefault(i => i.InstructorId == inst.InstructorId);
        if (oldinst != null)
        {
          inst = oldinst;
          inst.Active = false;
          db.Entry(oldinst).CurrentValues.SetValues(inst);
          db.SaveChanges();
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
    #endregion
  }
}
