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
    public class BridesmaidsClass
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
            var input = "bridesmaids";
            var clientBridesmaids = new RestClient("http://www.omdbapi.com/");
            var requestBridesmaids = new RestRequest("?t=" + input + "&y=&plot=short&r.json", Method.GET);
            var responseBridesmaids = new RestResponse();
            Task.Run(async () =>
            {
                responseBridesmaids = await GetResponseContentAsync(clientBridesmaids, requestBridesmaids) as RestResponse;
            }).Wait();
            BridesmaidsClass movieJsonBridesmaids = JsonConvert.DeserializeObject<BridesmaidsClass>(responseBridesmaids.Content);
            Dictionary<string, string> movieDataBridesmaids = new Dictionary<string, string>()
            {
                {"Title", movieJsonBridesmaids.Title },
                {"Year", movieJsonBridesmaids.Year },
                {"Director", movieJsonBridesmaids.Director },
                {"Genre", movieJsonBridesmaids.Genre },
                {"Actors", movieJsonBridesmaids.Actors },
                {"Plot", movieJsonBridesmaids.Plot },
                {"Poster", movieJsonBridesmaids.Poster }
            };

            return movieDataBridesmaids;

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
