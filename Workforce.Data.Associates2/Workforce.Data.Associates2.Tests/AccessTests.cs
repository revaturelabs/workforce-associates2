using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Data.Associates2.Domain;
using Xunit;

namespace Workforce.Data.Associates2.Tests
{
  public class AccessTests
  {
    AccessHelper ah = new AccessHelper();
    Address address = new Address()
    {
      City = "Perth Amboy",
      State = "New Jersery",
      Country = "USA",
      zipcode = "08861",
      address1 = "500 High st",
      address2 = "apt 4",
      Primary = true,
    };
    Batch batch = new Batch()
    {
      Name = "C#",
      Instructor = 1,
      StartDate = DateTime.Now,
      EndDate = DateTime.Now,
      Section = "1B" + DateTime.Now,
    };
    Gender gender = new Gender()
    {
      Name = "Male"
    };
    AssociateAddress associateAddress = new AssociateAddress()
    {
      AssociateID = 2,
      AddressID = 1
    };
    Instructor instructor = new Instructor()
    {
      FirstName = "Jimmy",
      LastName = "Johns"
    };
    Associate associate = new Associate()
    {
      FirstName = "First",
      LastName = "Last",
      GenderID = 1,
      BatchID = 1,
      PhoneNumber = "7321231233",
      Email = "come@me.net" + DateTime.Now,
      HasCar = true,
      HasKeys = true
    };

    #region gets
    [Fact]
    public void Test_GetAssociates()
    {
      Assert.True(ah.GetAssociates().Count >= 1);
    }
    [Fact]
    public void Test_GetAddress()
    {
      Assert.True(ah.GetAddress().Count >= 0);
    }
    [Fact]
    public void Test_GetAssociateAddress()
    {
      Assert.True(ah.GetAssociateAddress().Count >= 0);
    }
    [Fact]
    public void Test_GetBatch()
    {
      Assert.True(ah.GetBatch().Count >= 1);
    }
    [Fact]
    public void Test_GetGender()
    {
      Assert.True(ah.GetGender().Count >= 1);
    }
    [Fact]
    public void Test_GetInstructor()
    {
      Assert.True(ah.GetInstructor().Count >= 1);
    }
    #endregion

    #region inserts
    [Fact]
    public void Test_InsertAddress()
    {
      Assert.True(ah.InsertAddress(address));
    }
    [Fact]
    public void Test_InsertBatch()
    {
      batch.Section = "string" + DateTime.Now;
      Assert.True(ah.InsertBatch(batch));
    }
    [Fact]
    public void Test_InsertAssociateAddress()
    {
      Assert.True(ah.InsertAssociateAddress(associateAddress));
    }
    [Fact]
    public void Test_InsertGender()
    {
      Assert.True(ah.InsertGender(gender));
    }
    [Fact]
    public void Test_InsertInstructor()
    {
      Assert.True(ah.InsertInstructor(instructor));
    }
    [Fact]
    public void Test_InsertAssociate()
    {
      Assert.True(ah.InsertAssociate(associate));
    }
    #endregion

    #region updates
    [Fact]
    public void Test_UpdateAddress()
    {
      address.AddressId = 1;
      address.address1 = "update address" + DateTime.Now;
      Assert.True(ah.UpdateAddress(address));
    }
    [Fact]
    public void Test_UpdateBatch()
    {
      batch.BatchId = 1;
      batch.Name = "C# Update";
      Assert.True(ah.UpdateBatch(batch));
    }
    [Fact]
    public void Test_UpdateAssociateAddress()
    {
      associateAddress.AssociateAddressID = 1;
      associateAddress.AssociateID = 2;
      Assert.True(ah.UpdateAssociateAddress(associateAddress));
    }
    [Fact]
    public void Test_UpdateGender()
    {
      gender.GenderId = 3;
      gender.Name = "updated" + DateTime.Now;
      Assert.True(ah.UpdateGender(gender));
    }
    [Fact]
    public void Test_UpdateInstructor()
    {
      instructor.InstructorId = 1;
      instructor.FirstName = "updated" + DateTime.Now;
      Assert.True(ah.UpdateInstructor(instructor));
    }
    [Fact]
    public void Test_UpdateAssociate()
    {
      associate.AssociateID = 20;
      associate.FirstName = "updated";
      Assert.True(ah.UpdateAssociate(associate));
    }
    #endregion

    #region deletes
    [Fact]
    public void Test_DeleteAddress()
    {
      address.AddressId = 1;
      Assert.True(ah.DeleteAddress(address));
    }
    [Fact]
    public void Test_DeleteBatch()
    {
      Assert.True(ah.DeleteBatch(batch));
    }
    [Fact]
    public void Test_DeleteAssociateAddress()
    {
      associateAddress.AssociateAddressID = 1;
      Assert.True(ah.DeleteAssociateAddress(associateAddress));
    }
    [Fact]
    public void Test_DeleteGender()
    {
      gender.GenderId = 3;
      Assert.True(ah.DeleteGender(gender));
    }
    [Fact]
    public void Test_DeleteInstructor()
    {
      instructor.InstructorId = 1;
      Assert.True(ah.DeleteInstructor(instructor));
    }
    [Fact]
    public void Test_DeleteAssociate()
    {
      associate.AssociateID = 2;
      Assert.True(ah.DeleteAssociate(associate));
    }

    #endregion
  }
}
