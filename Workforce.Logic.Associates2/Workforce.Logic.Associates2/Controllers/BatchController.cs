using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Workforce.Logic.Associates2.Domain;
using Workforce.Logic.Associates2.Domain.DomainModels;

namespace Workforce.Logic.Associates2.Rest.Controllers
{
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class BatchController : ApiController
    {
      private readonly LogicHelper logic = new LogicHelper();
      private static readonly log4net.ILog logger = LogHelper.GetLogger();

      /// <summary>
      /// This 'Get' method will get every Associate that exists in the database
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindAll()
      {
         string status = "true"; // This line will be obsolete once the below issues have been corrected in a future update
         // The following line of code belongs to the FindByStatus API Call, but has been set here to temporarily resolve
         // an immediate issue that will be correctly resolved in a future update

         try
         {
           var response = Request.CreateResponse(HttpStatusCode.OK, await logic.GetAllBatches());
           logger.Info("Get all batches successful");
           return response;
         }

         catch (Exception ex)
         {
           LogHelper.ErrorLogger(logger, ex);
           return Request.CreateResponse(HttpStatusCode.BadRequest);
         }

      }

      /// <summary>
      /// This is the base 'Get' method for Associate that returns results based on active status
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindByStatus(string status)
      {
         // The line below originally belongs to the FindAll() API call. 
         // It is planned to be resolved in a future update as this (FindByStatus) API call
         // is not functioning for some unknown reason
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.GetBatchesByStatus(status));
          logger.Info("Get all batches by status successful");
          return response;
        }

        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }

      /// <summary>
      /// Adds a new Batch to the database
      /// </summary>
      [HttpPost]
      public async Task<HttpResponseMessage> Post([FromBody]BatchDto batch)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.AddNewBatch(batch));
          logger.Info("Add new batch successful");
          return response;
        }

        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }

      /// <summary>
      /// Deactivates (Deletes) an active Batch
      /// Must confirm if this will reactivate it too
      /// </summary>
      [HttpDelete]
      public async Task<HttpResponseMessage> Delete([FromBody]BatchDto batch)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.DeactivateBatch(batch));
          logger.Info("Delete batch successful");
          return response;
        }

        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }

      /// <summary>
      /// takes in key information to update a specific Batch
      /// </summary>
      [HttpPut]
      public async Task<HttpResponseMessage> Put([FromBody]BatchDto batch)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.UpdateBatch(batch));
          logger.Info("Update batch successful");
          return response;
        }

        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }
   }
}
