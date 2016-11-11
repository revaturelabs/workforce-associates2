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
  public class AssociateController : ApiController
   {
      private readonly LogicHelper logic = new LogicHelper();

      /// <summary>
      /// This 'Get' method will get every Associate that exists in the database
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> FindAll()
      {
         string status = "true"; // This line will be obsolete once the below issues have been corrected in a future update
         // The following line of code belongs to the FindByStatus API Call, but has been set here to temporarily resolve
         // an immediate issue that will be correctly resolved in a future update
         return Request.CreateResponse(HttpStatusCode.OK, await logic.GetAssociatesByStatus(status));
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
         return Request.CreateResponse(HttpStatusCode.OK, await logic.GetAllAssociates());
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpPost]
      public async Task<HttpResponseMessage> Post([FromBody]AssociateDto associate)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.AddNewAssociate(associate));
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpDelete]
      public async Task<HttpResponseMessage> Delete([FromBody]AssociateDto associate)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.DeactivateAssociate(associate));
      }

      /// <summary>
      /// 
      /// </summary>
      [HttpPut]
      public async Task<HttpResponseMessage> Put([FromBody]AssociateDto associate)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.UpdateAssociate(associate));
      }
   }
}