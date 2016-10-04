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
    public class MementoClass
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
            var input = "memento";
            var clientMemento = new RestClient("http://www.omdbapi.com/");
            var requestMemento = new RestRequest("?t=" + input + "&y=&plot=short&r.json", Method.GET);
            var responseMemento = new RestResponse();
            Task.Run(async () =>
            {
                responseMemento = await GetResponseContentAsync(clientMemento, requestMemento) as RestResponse;
            }).Wait();
            MementoClass movieJsonMemento = JsonConvert.DeserializeObject<MementoClass>(responseMemento.Content);
            Dictionary<string, string> movieDataMemento = new Dictionary<string, string>()
            {
                {"Title", movieJsonMemento.Title },
                {"Year", movieJsonMemento.Year },
                {"Director", movieJsonMemento.Director },
                {"Genre", movieJsonMemento.Genre },
                {"Actors", movieJsonMemento.Actors },
                {"Plot", movieJsonMemento.Plot },
                {"Poster", movieJsonMemento.Poster }
            };

            return movieDataMemento;

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
