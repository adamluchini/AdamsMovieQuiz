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
            var input = "braveheart";
            var client = new RestClient("http://www.omdbapi.com/");
            var request = new RestRequest("?t=" + input + "&y=&plot=short&r.json", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            MovieClass movieJson = JsonConvert.DeserializeObject<MovieClass>(response.Content);
            Dictionary<string, string> movieData = new Dictionary<string, string>()
            {
                {"Title:", movieJson.Title },
                {"Year:", movieJson.Year }
            };
            List<string> list = new List<string>(movieData.Keys);
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
