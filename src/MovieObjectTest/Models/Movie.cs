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
    public class MovieClass
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public static Dictionary<string, string> GetMovie()
        {
            
            var input1 = "argo";
            var client1 = new RestClient("http://www.omdbapi.com/");
            var request1 = new RestRequest("?t=" + input1 + "&y=&plot=short&r.json", Method.GET);
            var response1 = new RestResponse();
            Task.Run(async () =>
            {
                response1 = await GetResponseContentAsync(client1, request1) as RestResponse;
            }).Wait();
            MovieClass movieJson1 = JsonConvert.DeserializeObject<MovieClass>(response1.Content);
            Dictionary<string, string> movieData = new Dictionary<string, string>()
            {
                {"Title:", movieJson1.Title },
                {"Year:", movieJson1.Year }
            };
            

            var input2 = "braveheart";
            var client2 = new RestClient("http://www.omdbapi.com/");
            var request2 = new RestRequest("?t=" + input2 + "&y=&plot=short&r.json", Method.GET);
            var response2 = new RestResponse();
            Task.Run(async () =>
            {
                response2 = await GetResponseContentAsync(client2, request2) as RestResponse;
            }).Wait();
            MovieClass movieJson2 = JsonConvert.DeserializeObject<MovieClass>(response2.Content);
            Dictionary<string, string> movieData2 = new Dictionary<string, string>()
            {
                {"Title:", movieJson2.Title },
                {"Year:", movieJson2.Year }
            };

            // List<string> list = new List<string>(movieData.Keys);
            return movieData;
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
