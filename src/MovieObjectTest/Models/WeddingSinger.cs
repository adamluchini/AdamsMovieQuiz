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
    public class WeddingSingerClass
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }

        public static Dictionary<string, string> GetMovie()
        {
            /* string[] movieList = { "argo", "braveheart" };
             var input = "";
             for (var i = 0; i < movieList.Length; i++)
             {
                 input = movieList[0];
                 input = movieList[1];
             } */
            var input = "wedding+singer";
            var clientWeddingSinger = new RestClient("http://www.omdbapi.com/");
            var requestWeddingSinger = new RestRequest("?t=" + input + "&y=&plot=short&r.json", Method.GET);
            var responseWeddingSinger = new RestResponse();
            Task.Run(async () =>
            {
                responseWeddingSinger = await GetResponseContentAsync(clientWeddingSinger, requestWeddingSinger) as RestResponse;
            }).Wait();
            WeddingSingerClass movieJsonWeddingSinger = JsonConvert.DeserializeObject<WeddingSingerClass>(responseWeddingSinger.Content);
            Dictionary<string, string> movieDataWeddingSinger = new Dictionary<string, string>()
            {
                {"Title", movieJsonWeddingSinger.Title },
                {"Year", movieJsonWeddingSinger.Year },
                {"Director", movieJsonWeddingSinger.Director },
                {"Genre", movieJsonWeddingSinger.Genre },
                {"Actors", movieJsonWeddingSinger.Actors },
                {"Plot", movieJsonWeddingSinger.Plot },
                {"Poster", movieJsonWeddingSinger.Poster }
            };

            return movieDataWeddingSinger;

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
