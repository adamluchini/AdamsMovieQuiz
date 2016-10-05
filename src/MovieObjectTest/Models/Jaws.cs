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
    public class JawsClass
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
            /* string[] movieList = { "jaws", "braveheart" };
             var input = "";
             for (var i = 0; i < movieList.Length; i++)
             {
                 input = movieList[0];
                 input = movieList[1];
             } */
            var input = "jaws";
            var clientJaws = new RestClient("http://www.omdbapi.com/");
            var requestJaws = new RestRequest("?t=" + input + "&y=&plot=short&r.json", Method.GET);
            var responseJaws = new RestResponse();
            Task.Run(async () =>
            {
                responseJaws = await GetResponseContentAsync(clientJaws, requestJaws) as RestResponse;
            }).Wait();
            JawsClass movieJsonJaws = JsonConvert.DeserializeObject<JawsClass>(responseJaws.Content);
            Dictionary<string, string> movieDataJaws = new Dictionary<string, string>()
            {
                {"Title", movieJsonJaws.Title },
                {"Year", movieJsonJaws.Year },
                {"Director", movieJsonJaws.Director },
                {"Genre", movieJsonJaws.Genre },
                {"Actors", movieJsonJaws.Actors },
                {"Plot", movieJsonJaws.Plot },
                {"Poster", movieJsonJaws.Poster }
            };

            return movieDataJaws;

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
