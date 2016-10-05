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
    public class DropDeadClass
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
            var input = "drop+dead+gorgeous";
            var clientDropDead = new RestClient("http://www.omdbapi.com/");
            var requestDropDead = new RestRequest("?t=" + input + "&y=&plot=short&r.json", Method.GET);
            var responseDropDead = new RestResponse();
            Task.Run(async () =>
            {
                responseDropDead = await GetResponseContentAsync(clientDropDead, requestDropDead) as RestResponse;
            }).Wait();
            DropDeadClass movieJsonDropDead = JsonConvert.DeserializeObject<DropDeadClass>(responseDropDead.Content);
            Dictionary<string, string> movieDataDropDead = new Dictionary<string, string>()
            {
                {"Title", movieJsonDropDead.Title },
                {"Year", movieJsonDropDead.Year },
                {"Director", movieJsonDropDead.Director },
                {"Genre", movieJsonDropDead.Genre },
                {"Actors", movieJsonDropDead.Actors },
                {"Plot", movieJsonDropDead.Plot },
                {"Poster", movieJsonDropDead.Poster }
            };

            return movieDataDropDead;

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
