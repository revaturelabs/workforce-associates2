using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Associates2.Domain
{
  public class HousingRestConnector
  {
    public void GetPOSTResponse(Uri uri, string data, Action<int?> callback)
    {
      HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

      request.Method = "POST";
      request.ContentType = "text/plain;charset=utf-8";

      System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
      byte[] bytes = encoding.GetBytes(data);

      request.ContentLength = bytes.Length;

      using (Stream requestStream = request.GetRequestStream())
      {
        // Send the data.
        requestStream.Write(bytes, 0, bytes.Length);
      }

      request.BeginGetResponse((x) =>
      {
        using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(x))
        {
          if (callback != null)
          {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(int?));
            callback(ser.ReadObject(response.GetResponseStream()) as int?);
          }
        }
      }, null);
    }



  }
}
