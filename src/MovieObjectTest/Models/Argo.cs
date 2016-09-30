using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using MovieObjectTest.Controllers;
using Newtonsoft.Json.Linq;

namespace MovieObjectTest.Models
{
    public class ArgoClass
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public static Dictionary<string, string> GetMovie()
        {
            
            var inputArgo = "argo";
            var clientArgo = new RestClient("http://www.omdbapi.com/");
            var requestArgo = new RestRequest("?t=" + inputArgo + "&y=&plot=short&r.json", Method.GET);
            var responseArgo = new RestResponse();
            Task.Run(async () =>
            {
                responseArgo = await GetResponseContentAsync(clientArgo, requestArgo) as RestResponse;
            }).Wait();
            BraveHeartClass movieJsonArgo = JsonConvert.DeserializeObject<BraveHeartClass>(responseArgo.Content);
            Dictionary<string, string> movieDataArgo = new Dictionary<string, string>()
            {
                {"Title:", movieJsonArgo.Title },
                {"Year:", movieJsonArgo.Year }
            };
            return movieDataArgo;
            // List<string> list = new List<string>(movieData.Keys);
        }
        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
