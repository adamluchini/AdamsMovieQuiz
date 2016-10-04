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
    public class InsideManClass
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
            var input = "inside+man";
            var clientInsideMan = new RestClient("http://www.omdbapi.com/");
            var requestInsideMan = new RestRequest("?t=" + input + "&y=&plot=short&r.json", Method.GET);
            var responseInsideMan = new RestResponse();
            Task.Run(async () =>
            {
                responseInsideMan = await GetResponseContentAsync(clientInsideMan, requestInsideMan) as RestResponse;
            }).Wait();
            InsideManClass movieJsonInsideMan = JsonConvert.DeserializeObject<InsideManClass>(responseInsideMan.Content);
            Dictionary<string, string> movieDataInsideMan = new Dictionary<string, string>()
            {
                {"Title", movieJsonInsideMan.Title },
                {"Year", movieJsonInsideMan.Year },
                {"Director", movieJsonInsideMan.Director },
                {"Genre", movieJsonInsideMan.Genre },
                {"Actors", movieJsonInsideMan.Actors },
                {"Plot", movieJsonInsideMan.Plot },
                {"Poster", movieJsonInsideMan.Poster }
            };

            return movieDataInsideMan;

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
