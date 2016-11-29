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
  public class InstructorController : ApiController
    {
      private readonly LogicHelper logic = new LogicHelper();
      private static readonly log4net.ILog logger = LogHelper.GetLogger();

      /// <summary>
      /// This 'Get' method returns all Instructors regardless of status
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindAll()
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.GetAllInstructors());
          logger.Info("Get all instructors successful");
          return response;
        }

        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }

      /// <summary>
      /// This is the base 'Get' method for Instructors that retrieves based on status
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindByStatus(string status)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.GetInstructorsByStatus(status));
          logger.Info("Get all instructors by status successful");
          return response;
        }

        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }

      /// <summary>
      /// Adds a new Instructor to the database
      /// </summary>
      [HttpPost]
      public async Task<HttpResponseMessage> Post([FromBody]InstructorDto instructor)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.AddNewInstructor(instructor));
          logger.Info("Create new instructor successful");
          return response;
        }

        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }

      /// <summary>
      /// Deactivates (Deletes) an active Instructor
      /// Must confirm if this will reactivate it too
      /// </summary>
      [HttpDelete]
      public async Task<HttpResponseMessage> Delete([FromBody]InstructorDto instructor)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.DeactivateInstructor(instructor));
          logger.Info("Delete instructor successful");
          return response;
        }

        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        } 
      }

      /// <summary>
      /// takes in key information to update a specific Instructor
      /// </summary>
      [HttpPut]
      public async Task<HttpResponseMessage> Put([FromBody]InstructorDto instructor)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.UpdateInstructor(instructor));
          logger.Info("Update instructor successful");
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
