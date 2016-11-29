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
  public class AddressController : ApiController
   {
      private readonly LogicHelper logic = new LogicHelper();
      private static readonly log4net.ILog logger = LogHelper.GetLogger();

      /// <summary>
      /// This 'Get' method returns all Associates regardless of status
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindAll()
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.GetAllAddresses());
          logger.Info("Get all addresses successful");
          return response;
        }

        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }

      /// <summary>
      /// This is the base 'Get' method for Associate that retrieves data based on status
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindByStatus(string status)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.GetAddressesByStatus(status));
          logger.Info("Get all addresses by status successful");
          return response;
        }

        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpPost]
      public async Task<HttpResponseMessage> Post([FromBody]AddressDto address)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.AddNewAddress(address));
          logger.Info("Add new address successful");
          return response;
        }

        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        } 
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpDelete]
      public async Task<HttpResponseMessage> Delete([FromBody]AddressDto address)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.DeactivateAddress(address));
          logger.Info("Delete address successful");
          return response;
        }

        catch (Exception ex)
        {
          LogHelper.ErrorLogger(logger, ex);
          return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpPut]
      public async Task<HttpResponseMessage> Put([FromBody]AddressDto address)
      {
        try
        {
          var response = Request.CreateResponse(HttpStatusCode.OK, await logic.UpdateAddress(address));
          logger.Info("Update address successful");
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
