using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Associates2.Domain
{
  public class HousingRestConnector
  {
    public async Task<HttpStatusCode> GetDeleteResponse(Uri uri, string data)
    {
      //System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
      //byte[] bytes = encoding.GetBytes(data);
      

      var request = new HttpClient();
      var destinationString = uri + "/" + data;
      HttpResponseMessage response = await request.DeleteAsync(destinationString);
      return response.StatusCode;
    }



  }
}
