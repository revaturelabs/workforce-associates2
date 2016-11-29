using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Workforce.Logic.Associates2.Controllers
{
  public class LogController : ApiController
  {
    public async Task<HttpResponseMessage> Get()
    {
      var path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "../AssociateLogicLog.log"; //the name of the latest log
      var reader = new StreamReader(path);
      string LogInformation = await reader.ReadToEndAsync();
      reader.Dispose();
      return Request.CreateResponse(HttpStatusCode.OK, LogInformation);
    }
  }
}
