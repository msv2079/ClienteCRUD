using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace ClienteCRUDLogica
{
    public interface IRequestLogica
    {
        dynamic ExecutarRequest(string url);
    }  

    public class RequestLogica : IRequestLogica
    {
        public dynamic ExecutarRequest(string url) 
        {
            dynamic result = null;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AllowAutoRedirect = false;
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (Stream webStream = response.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            var strResponse = responseReader.ReadToEnd();

                            result = JsonConvert.DeserializeObject<dynamic>(strResponse);
                        }
                    }
                }
            }

            return result;
        }
    }
}
