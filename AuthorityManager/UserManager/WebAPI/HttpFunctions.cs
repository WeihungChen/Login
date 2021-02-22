using System;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using AuthorityAPI.Models;

namespace UserManager
{
    static public class HttpFunctions
    {
        static private HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = true });

        static public ResultModel<T> Get<T>(string url, params object[] parameters)
        {
            foreach (object param in parameters)
            {
                if (param.GetType() == typeof(DateTime))
                    url += $"_{((DateTime)param).ToString("yyyy-MM-dd")}";
                else
                    url += $"_{param.ToString()}";
            }
            HttpResponseMessage response = client.GetAsync(url).Result;
            return JsonConvert.DeserializeObject<ResultModel<T>>(response.Content.ReadAsStringAsync().Result);
        }

        static public ResultModel<T> Post<T>(string url, object obj = null)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            return JsonConvert.DeserializeObject<ResultModel<T>>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
