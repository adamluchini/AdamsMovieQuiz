using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using MovieObjectTest.Controllers;
using Newtonsoft.Json.Linq;

/*
namespace MovieObjectTest.Models
{
    public class BraveHeartClass
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public static Dictionary<string, string> GetMovie()
        {

            var inputBraveHeart = "braveheart";
            var clientBraveHeart = new RestClient("http://www.omdbapi.com/");
            var requestBraveHeart = new RestRequest("?t=" + inputBraveHeart + "&y=&plot=short&r.json", Method.GET);
            var responseBraveHeart = new RestResponse();
            Task.Run(async () =>
            {
                responseBraveHeart = await GetResponseContentAsync(clientBraveHeart, requestBraveHeart) as RestResponse;
            }).Wait();
            BraveHeartClass movieJsonBraveHeart = JsonConvert.DeserializeObject<BraveHeartClass>(responseBraveHeart.Content);
            Dictionary<string, string> movieDataBraveHeart = new Dictionary<string, string>()
            {
                {"Title:", movieJsonBraveHeart.Title },
                {"Year:", movieJsonBraveHeart.Year }
            };
            return movieDataBraveHeart;
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
*/
