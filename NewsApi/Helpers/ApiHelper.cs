
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NewsApi.Helpers
{
    public class ApiHelper
    {
        public static dynamic ApiGet(string endpoint, Dictionary<string, string> urlParams)
        {
            Task<string> task = RunAsync(endpoint, urlParams);
            task.Wait();
            string result =  task.Result;
            return JsonConvert.DeserializeObject(result);
        }

        public static async Task<string> RunAsync(string endpoint, Dictionary<string, string> urlParams)
        {
            string stringResult = null;
            string query = "";
            foreach(var key in urlParams.Keys)
            {
                query = query + (query.Length > 0 ? "&" : "") + (key + "=" + urlParams[key]);
            }
            string _apiKey = Startup.StaticConfig.GetSection("AppSettings")["GuardianApiKey"];
            string urlString = endpoint + "?" + query + "&api-key=" + _apiKey;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://content.guardianapis.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                

                // HTTP GET
                //var response = client.GetAsync("search?format=json&from-date=2020-01-01&show-fields=headline,webUrl,thumbnail,webPublicationDate&show-elements=image&order-by=relevance&api-key=test");
                var response = client.GetAsync(urlString);
                response.Wait();
                HttpResponseMessage result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    stringResult = await result.Content.ReadAsStringAsync();
                }
            }
            return stringResult;
        }
    }
}
