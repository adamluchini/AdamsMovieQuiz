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
            var input = "argo";            
            var clientArgo = new RestClient("http://www.omdbapi.com/");
            var requestArgo = new RestRequest("?t=" + input + "&y=&plot=short&r.json", Method.GET);
            var responseArgo = new RestResponse();
            Task.Run(async () =>
            {
                responseArgo = await GetResponseContentAsync(clientArgo, requestArgo) as RestResponse;
            }).Wait();
            ArgoClass movieJsonArgo = JsonConvert.DeserializeObject<ArgoClass>(responseArgo.Content);
            Dictionary<string, string> movieDataArgo = new Dictionary<string, string>()
            {
                {"Title", movieJsonArgo.Title },
                {"Year", movieJsonArgo.Year },
                {"Director", movieJsonArgo.Director },
                {"Genre", movieJsonArgo.Genre },
                {"Actors", movieJsonArgo.Actors },
                {"Plot", movieJsonArgo.Plot },
                {"Poster", movieJsonArgo.Poster }
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
