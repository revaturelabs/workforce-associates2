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
  public class GenderController : ApiController
    {
      private readonly LogicHelper logic = new LogicHelper();

      /// <summary>
      /// This is the base 'Get' method for Gender
      /// </summary>
      [HttpGet]
      public async Task<HttpResponseMessage> Get()
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.GetAllGenders());
      }

      /// <summary>
      /// This is the base Insert (Post) method for Gender
      /// </summary>
      [HttpPost]
      public async Task<HttpResponseMessage> Post([FromBody]GenderDto gender)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.AddNewGender(gender));
      }

      /// <summary>
      /// This is the base 'Delete' method for Gender
      /// </summary>
      [HttpDelete]
      public async Task<HttpResponseMessage> Delete([FromBody]GenderDto gender)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.DeactivateGender(gender));
      }

      /// <summary>
      /// This is the base Update (Put) method for Gender
      /// </summary>
      [HttpPut]
      public async Task<HttpResponseMessage> Put([FromBody]GenderDto gender)
      {
         return Request.CreateResponse(HttpStatusCode.OK, await logic.UpdateGender(gender));
      }
   }
}
