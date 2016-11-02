using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Data.Associates2.Soap;
using Workforce.Data.Associates2.Soap.ServiceModels;
using Xunit;

namespace Workforce.Data.Associates2.Tests
{
  public class SoapTests
  {

    AssociateService fs = new AssociateService();
    AddressDao address = new AddressDao()
    {
      City = "Perth Amboy",
      State = "New Jersery",
      Country = "USA",
      Zipcode = "08861",
      Address1 = "500 High st",
      Address2 = "apt 4",
      Primary = true,
    };
    BatchDao batch = new BatchDao()
    {
      Name = "C#",
      Instructor = 1,
      StartDate = DateTime.Now,
      EndDate = DateTime.Now,
      Section = "1B" + DateTime.Now,
    };
    GenderDao gender = new GenderDao()
    {
      Name = "Male"
    };

    AssociateAddressDao associateAddress = new AssociateAddressDao()
    {
      AssociateID = 2,
      AddressID = 1
    };
    InstructorDao instructor = new InstructorDao()
    {
      InstructorId = 2,
      FirstName = "Jimmy",
      LastName = "Johns"
    };
    AssociateDao associate = new AssociateDao()
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
    [Fact]
    #region gets
    public void Test_GetInstructor()
    {
      var instructors = fs.GetInstructor();
      Assert.True(instructors.Count > 0);
    }
    [Fact]
    public void Test_GetAddress()
    {
      var address = fs.GetAddress();
      Assert.True(address.Count > 0);
    }
    [Fact]
    public void Test_GetAssociateAddress()
    {
      var aa = fs.GetAssociateAddress();
      Assert.True(aa.Count > 0);
    }
    [Fact]
    public void Test_GetAssocaite()
    {
      var a = fs.GetAssociates();
      Assert.True(a.Count > 0);
    }
    #endregion
    #region inserts
    [Fact]
    public void Test_InsertAddress()
    {
      var a = fs.InsertAddress(address);
    }
    [Fact]
    public void Test_InsertAssociateAddress()
    {
      var a = fs.InsertAssociateAddress(associateAddress);
    }
    [Fact]
    public void Test_InsertAssociate()
    {
      var a = fs.InsertAssociate(associate);
    }
    [Fact]
    public void Test_InsertBatch()
    {
      var a = fs.InsertBatch(batch);
    }
    [Fact]
    public void Test_InsertGender()
    {
      var a = fs.InsertGender(gender);
    }
    [Fact]
    public void Test_InsertInstructor()
    {
      var a = fs.InsertInstructor(instructor);
    }

    #endregion
    #region updates
    [Fact]
    public void Test_UpdateBatch()
    {
      var a = fs.UpdateBatch(batch);
      Assert.True(a);
    }
    [Fact]
    public void Test_UpdateGender()
    {
      var a = fs.UpdateGender(gender);
      Assert.True(a);
    }
    [Fact]
    public void Test_UpdateAddress()
    {
      var a = fs.UpdateAddress(address);
      Assert.True(a);
    }
    [Fact]
    public void Test_UpdateInstructor()
    {
      instructor.FirstName = "updated" + DateTime.Now;
      var a = fs.UpdateInstructor(instructor);
      Assert.True(a);
    }
    [Fact]
    public void Test_UpdateAssociate()
    {
      var a = fs.UpdateAssociate(associate);
      Assert.True(a);
    }
    [Fact]
    public void Test_UpdateAssociateAddress()
    {
      var a = fs.UpdateAssociateAddress(associateAddress);
      Assert.True(a);
    }
    #endregion
    #region deletes
    public void Test_DeleteAddress()
    {
      var a = fs.DeleteAddress(address);
      Assert.True(a);
    }
    public void Test_DeleteAssociate()
    {
      var a = fs.DeleteAssociate(associate);
      Assert.True(a);
    }
    public void Test_DeleteAssociateAddress()
    {
      var a = fs.DeleteAssociateAddress(associateAddress);
      Assert.True(a);
    }
    public void Test_DeleteBatch()
    {
      var a = fs.DeleteBatch(batch);
      Assert.True(a);
    }
    public void Test_DeleteGender()
    {
      var a = fs.DeleteGender(gender);
      Assert.True(a);
    }
    public void Test_DeleteInstructor()
    {
      var a = fs.DeleteInstructor(instructor);
      Assert.True(a);
    }
    #endregion
  }
}
