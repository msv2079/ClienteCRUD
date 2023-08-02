using webMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace ClienteCRUDMVC.Util
{
    public interface IRequestUtil
    {
        dynamic SendRequest(string endPoint, webMethod.HttpMethod method = webMethod.HttpMethod.Get, string json = "");
    }

    public class RequestUtil : IRequestUtil
    {
        private readonly IOptions<ClienteCRUDConfig> _config;
        public RequestUtil(IOptions<ClienteCRUDConfig> config)
        {
            _config = config;
        }

        public dynamic SendRequest(string endPoint, webMethod.HttpMethod method = webMethod.HttpMethod.Get, string json = "")
        {
            dynamic result = null;

            var urlCompleta = $"{_config.Value.BasePathWebApi}/{endPoint}";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(urlCompleta);
                request.Method = method.ToString();
                request.AllowAutoRedirect = false;

                if (method == webMethod.HttpMethod.Post || method == webMethod.HttpMethod.Put)
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(json);

                    request.ContentType = "application/json";
                    request.ContentLength = byteArray.Length;

                    using var reqStream = request.GetRequestStream();
                    reqStream.Write(byteArray, 0, byteArray.Length);
                }

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
            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    {
                        string text = new StreamReader(data).ReadToEnd();
                        throw new Exception(text);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
