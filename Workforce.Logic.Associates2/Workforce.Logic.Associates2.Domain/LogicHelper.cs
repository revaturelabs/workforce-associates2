using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Workforce.Logic.Associates2.Domain.DomainModels;
using Workforce.Logic.Associates2.Domain.WFSReference;

namespace Workforce.Logic.Associates2.Domain
{
  public class LogicHelper
  {
    /// <summary>
    /// These are the primers for calling specific references
    /// </summary>
    private readonly AssociateServiceClient client = new AssociateServiceClient();
    private readonly HousingRestConnector HRConnector = new HousingRestConnector();
    private readonly Associate associateLogic = new Associate();
    private readonly Address addressLogic = new Address();
    private readonly Batch batchLogic = new Batch();
    private readonly Gender genderLogic = new Gender();
    private readonly Instructor instructorLogic = new Instructor();

    #region All methods related to Associate
    /// <summary>
    /// Basic 'Get' method that retrieves all associates regardless of active status
    /// </summary>
    public async Task<List<AssociateDto>> GetAllAssociates()
    {
      var associate = new List<AssociateDto>();
      var serviceAssociates = await client.GetAssociatesAsync();
      var serviceGenders = await client.GetGenderAsync();
      var serviceBatches = await client.GetBatchesAsync();

      foreach (var item in serviceAssociates)
      {
        if (associateLogic.ValidateSoapData(item))
        {
          // The following lines parse the collected data and convert BatchID/GenderID to their associated Names
          var parse = associateLogic.MapToRest(item);
          parse.Gender = serviceGenders.FirstOrDefault(g => g.GenderID.Equals(item.GenderID)).Name;
          parse.Batch = serviceBatches.FirstOrDefault(b => b.BatchID.Equals(item.BatchID)).Name;

          // Store the parsed data
          associate.Add(parse);
        }
      }
      return associate;
    }

    /// <summary>
    /// Basic 'Get' method that retrieves all associates based on active status
    /// </summary>
    public async Task<List<AssociateDto>> GetAssociatesByStatus(string status)
    {
      var associate = new List<AssociateDto>();
      var serviceAssociates = await client.GetAssociatesAsync();
      var serviceGenders = await client.GetGenderAsync();
      var serviceBatches = await client.GetBatchesAsync();

      foreach (var item in serviceAssociates)
      {
        if (status == "true") //return all active associates
        {
          if (associateLogic.ValidateSoapData(item) && item.Active)
          {
            // The following lines parse the collected data and convert BatchID/GenderID to their associated Names
            var parse = associateLogic.MapToRest(item);
            parse.Gender = serviceGenders.FirstOrDefault(g => g.GenderID.Equals(item.GenderID)).Name;
            parse.Batch = serviceBatches.FirstOrDefault(b => b.BatchID.Equals(item.BatchID)).Name;
            
            // Store the parsed data
            associate.Add(parse);
          }
        }
        else //return all deactive associates
        {
          if (associateLogic.ValidateSoapData(item) && item.Active == false)
          {
            // The following lines parse the collected data and convert BatchID/GenderID to their associated Names
            var parse = associateLogic.MapToRest(item);
            parse.Gender = serviceGenders.FirstOrDefault(g => g.GenderID.Equals(item.GenderID)).Name;
            parse.Batch = serviceBatches.FirstOrDefault(b => b.BatchID.Equals(item.BatchID)).Name;

            // Store the parsed data
            associate.Add(parse);
          }
        }
      }
      return associate;
    }

    /// <summary>
    /// Attempts to add a new associate after ensuring that the data entered is valid
    /// </summary>
    public async Task<bool> AddNewAssociate(AssociateDto newAssociate)
    {
      if (associateLogic.ValidateRestData(newAssociate))
      {
        // Collect all Genders and Batches
        var serviceGenders = await client.GetGenderAsync();
        var serviceBatch = await client.GetBatchesAsync();
        
        // Convert Name to ID
        newAssociate.Gender = serviceGenders.FirstOrDefault(g => g.Name.Equals(newAssociate.Gender)).GenderID.ToString();
        newAssociate.Batch = serviceBatch.FirstOrDefault(b => b.Name.Equals(newAssociate.Batch)).BatchID.ToString();
        
        // Pass converted data down to Data layer and await a pass/fail response
        return await client.InsertAssociateAsync(associateLogic.MapToSoap(newAssociate));
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// Changes the active status of an associate
    /// This is essentially the 'Delete' method
    /// </summary>
    public async Task<bool> DeactivateAssociate(AssociateDto delAssociate)
    {
      if (associateLogic.ValidateRestData(delAssociate))
      {
        //the following two lines gather all batches and all genders from the database
        var serviceGenders = await client.GetGenderAsync();
        var serviceBatches = await client.GetBatchesAsync();

        // the following two lines convert the batch/gender Name to the matching ID as a string
        delAssociate.Gender = serviceGenders.FirstOrDefault(g => g.Name.Equals(delAssociate.Gender)).GenderID.ToString();
        delAssociate.Batch = serviceBatches.FirstOrDefault(b => b.Name.Equals(delAssociate.Batch)).BatchID.ToString();

        // The following two lines add an API call to the Housing side to trigger a secondary delete
        var thestring = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/workforce-housing-rest/api/housingdata";
        var theUri = new Uri(thestring);
        // Deletes the associated Housing data attached to the associate being deleted
        var resultMessage = HRConnector.GetDeleteResponse(theUri, delAssociate.AssociateID.ToString());

        // Pass converted data down to Data layer and await a pass/fail response
        return await client.DeleteAssociateAsync(associateLogic.MapToSoap(delAssociate));
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// This is the basic 'Update' method for Associate
    /// </summary>
    public async Task<bool> UpdateAssociate(AssociateDto update)
    {
      if (associateLogic.ValidateRestData(update))
      {
        // collect all genders and batches
        var serviceGenders = await client.GetGenderAsync();
        var serviceBatches = await client.GetBatchesAsync();
        
        // convert Gender Name and Batch Name to the associated ID
        update.Gender = serviceGenders.FirstOrDefault(g => g.Name.Equals(update.Gender)).GenderID.ToString();
        update.Batch = serviceBatches.FirstOrDefault(b => b.Name.Equals(update.Batch)).BatchID.ToString();

        // store newly updated object and map it
        var keepStatus = associateLogic.MapToSoap(update);

        // maintain 'Active' status so that it doesn't auto convert to false
        keepStatus.Active = true;

        // Pass converted data down to Data layer and await a pass/fail response
        return await client.UpdateAssociateAsync(keepStatus);
      }
      else
      {
        return false;
      }
    }
    #endregion

    #region All methods related to Address
    /// <summary>
    /// Basic 'Get' method that retrieves all addresses regardless of active status
    /// </summary>
    public async Task<List<AddressDto>> GetAllAddresses()
    {
      var address = new List<AddressDto>();
      var serviceAddress = await client.GetAddressAsync();

      foreach (var item in serviceAddress)
      {
        if (addressLogic.ValidateSoapData(item) && item.Active)
        {
          address.Add(addressLogic.MapToRest(item));
        }
      }
      return address;
    }

    /// <summary>
    /// Base 'Get' method that retrieves all addresses based on active status
    /// </summary>
    public async Task<List<AddressDto>> GetAddressesByStatus(string status)
    {
      var address = new List<AddressDto>();
      var serviceAddress = await client.GetAddressAsync();

      foreach (var item in serviceAddress)
      {
        if (status == "true")
        {
          if (addressLogic.ValidateSoapData(item) && item.Active)
          {
            address.Add(addressLogic.MapToRest(item));
          }
        }
        else
        {
          if (addressLogic.ValidateSoapData(item) && item.Active == false)
          {
            address.Add(addressLogic.MapToRest(item));
          }
        }
      }
      return address;
    }

    /// <summary>
    /// Attempts to add a new address after ensuring that the data entered is valid
    /// </summary>
    public async Task<bool> AddNewAddress(AddressDto newAddress)
    {
      if (addressLogic.ValidateRestData(newAddress))
      {
        return await client.InsertAddressAsync(addressLogic.MapToSoap(newAddress));
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// Changes the active status of an address
    /// This is essentially the 'Delete' method
    /// </summary>
    public async Task<bool> DeactivateAddress(AddressDto delAddress)
    {
      if (addressLogic.ValidateRestData(delAddress))
      {
        return await client.DeleteAddressAsync(addressLogic.MapToSoap(delAddress));
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// This is the basic 'Update' method for Address
    /// </summary>
    public async Task<bool> UpdateAddress(AddressDto update)
    {
      if (addressLogic.ValidateRestData(update))
      {
        var keepStatus = addressLogic.MapToSoap(update);
        keepStatus.Active = true;

        return await client.UpdateAddressAsync(keepStatus);
      }
      else
      {
        return false;
      }
    }
    #endregion

    #region All methods related to Batch
    /// <summary>
    /// This 'Get' method retrieves all batches regardless of active status
    /// </summary>
    public async Task<List<BatchDto>> GetAllBatches()
    {
      var batches = new List<BatchDto>();
      var serviceBatches = await client.GetBatchesAsync();

      foreach (var item in serviceBatches)
      {
        if (batchLogic.ValidateSoapData(item))
        {
          batches.Add(batchLogic.MapToRest(item));
        }
      }
      return batches;
    }

    /// <summary>
    /// Basic 'Get' method that retrieves all batches based on active status
    /// </summary>
    public async Task<List<BatchDto>> GetBatchesByStatus(string status)
    {
      var batches = new List<BatchDto>();
      var serviceBatches = await client.GetBatchesAsync();

      foreach (var item in serviceBatches)
      {
        if (status == "true")
        {
          if (batchLogic.ValidateSoapData(item) && item.Active)
          {
            batches.Add(batchLogic.MapToRest(item));
          }
        }
        else
        {
          if (batchLogic.ValidateSoapData(item) && item.Active == false)
          {
            batches.Add(batchLogic.MapToRest(item));
          }
        }
      }
      return batches;
    }

    /// <summary>
    /// Attempts to add a new batch after ensuring that the data entered is valid
    /// </summary>
    public async Task<bool> AddNewBatch(BatchDto newBatch)
    {
      if (batchLogic.ValidateRestData(newBatch))
      {
        return await client.InsertBatchAsync(batchLogic.MapToSoap(newBatch));
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// Changes the active status of a batch
    /// This is essentially the 'Delete' method
    /// </summary>
    public async Task<bool> DeactivateBatch(BatchDto delBatch)
    {
      if (batchLogic.ValidateRestData(delBatch))
      {
        return await client.DeleteBatchAsync(batchLogic.MapToSoap(delBatch));
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// This is the basic 'Update' method for Batch
    /// </summary>
    public async Task<bool> UpdateBatch(BatchDto update)
    {
      if (batchLogic.ValidateRestData(update))
      {
        var keepStatus = batchLogic.MapToSoap(update);
        keepStatus.Active = true;

        return await client.UpdateBatchAsync(keepStatus);
      }
      else
      {
        return false;
      }
    }
    #endregion

    #region All methods related to Gender
    /// <summary>
    /// Basic 'Get' method that retrieves all genders regardless of active status
    /// </summary>
    public async Task<List<GenderDto>> GetAllGenders()
    {
      var genders = new List<GenderDto>();

      var serviceGenders = await client.GetGenderAsync();

      foreach (var item in serviceGenders)
      {
        if (genderLogic.ValidateSoapData(item) && item.Active)
        {
          genders.Add(genderLogic.MapToRest(item));
        }
      }
      return genders;
    }

    /// <summary>
    /// Attempts to add a new gender after ensuring that the data entered is valid
    /// </summary>
    public async Task<bool> AddNewGender(GenderDto newGender)
    {
      if (genderLogic.ValidateRestData(newGender))
      {
        return await client.InsertGenderAsync(genderLogic.MapToSoap(newGender));
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// Changes the active status of a gender
    /// This is essentially the 'Delete' method
    /// </summary>
    public async Task<bool> DeactivateGender(GenderDto delGender)
    {
      if (genderLogic.ValidateRestData(delGender))
      {
        return await client.DeleteGenderAsync(genderLogic.MapToSoap(delGender));
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// This is the basic 'Update' method for Instructor
    /// </summary>
    public async Task<bool> UpdateGender(GenderDto update)
    {
      if (genderLogic.ValidateRestData(update))
      {
        var keepStatus = genderLogic.MapToSoap(update);
        keepStatus.Active = true;

        return await client.UpdateGenderAsync(keepStatus);
      }
      else
      {
        return false;
      }
    }
    #endregion

    #region All methods related to Instructor
    /// <summary>
    /// The 'Get' method that retrieves all instructors regardless of active status
    /// </summary>
    public async Task<List<InstructorDto>> GetAllInstructors()
    {
      var instructors = new List<InstructorDto>();
      var serviceInstructors = await client.GetInstructorAsync();

      foreach (var item in serviceInstructors)
      {
        if (instructorLogic.ValidateSoapData(item) && item.Active)
        {
          instructors.Add(instructorLogic.MapToRest(item));
        }
      }
      return instructors;
    }

    /// <summary>
    /// This is the base 'Get' method for instructers that will resturn results based on active status
    /// </summary>
    /// <returns></returns>
    public async Task<List<InstructorDto>> GetInstructorsByStatus(string status)
    {
      var instructors = new List<InstructorDto>();
      var serviceInstructors = await client.GetInstructorAsync();

      foreach (var item in serviceInstructors)
      {
        if (instructorLogic.ValidateSoapData(item) && item.Active)
        {
          instructors.Add(instructorLogic.MapToRest(item));
        }
      }
      return instructors;
    }

    /// <summary>
    /// Basic 'Get' method that retrieves all instructors regardless of active status
    /// </summary>
    public async Task<List<InstructorDto>> GetByStatusInstructors()
    {
      var instructors = new List<InstructorDto>();

      try
      {
        var serviceInstructors = await client.GetInstructorAsync();

        foreach (var item in serviceInstructors)
        {
          if (instructorLogic.ValidateSoapData(item))
          {
            instructors.Add(instructorLogic.MapToRest(item));
          }
        }
        return instructors;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return instructors;
      }
    }
    /// <summary>
    /// Attempts to add a new instructor after ensuring that the data entered is valid
    /// </summary>
    public async Task<bool> AddNewInstructor(InstructorDto newInstructor)
    {
      if (instructorLogic.ValidateRestData(newInstructor))
      {
        return await client.InsertInstructorAsync(instructorLogic.MapToSoap(newInstructor));
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// Changes the active status of an instructor
    /// This is essentially the 'Delete' method
    /// </summary>
    public async Task<bool> DeactivateInstructor(InstructorDto delInstructor)
    {
      if (instructorLogic.ValidateRestData(delInstructor))
      {
        return await client.DeleteInstructorAsync(instructorLogic.MapToSoap(delInstructor));
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// This is the basic 'Update' method for Instructor
    /// </summary>
    public async Task<bool> UpdateInstructor(InstructorDto update)
    {
      if (instructorLogic.ValidateRestData(update))
      {
        return await client.UpdateInstructorAsync(instructorLogic.MapToSoap(update));
      }
      else
      {
        return false;
      }
    }
    #endregion
  }
}
