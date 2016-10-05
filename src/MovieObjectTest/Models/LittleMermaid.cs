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
    public class LittleMermaidClass
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
            /* string[] movieList = { "littlemermaid", "braveheart" };
             var input = "";
             for (var i = 0; i < movieList.Length; i++)
             {
                 input = movieList[0];
                 input = movieList[1];
             } */
            var input = "the+little+mermaid";
            var clientLittleMermaid = new RestClient("http://www.omdbapi.com/");
            var requestLittleMermaid = new RestRequest("?t=" + input + "&y=&plot=short&r.json", Method.GET);
            var responseLittleMermaid = new RestResponse();
            Task.Run(async () =>
            {
                responseLittleMermaid = await GetResponseContentAsync(clientLittleMermaid, requestLittleMermaid) as RestResponse;
            }).Wait();
            LittleMermaidClass movieJsonLittleMermaid = JsonConvert.DeserializeObject<LittleMermaidClass>(responseLittleMermaid.Content);
            Dictionary<string, string> movieDataLittleMermaid = new Dictionary<string, string>()
            {
                {"Title", movieJsonLittleMermaid.Title },
                {"Year", movieJsonLittleMermaid.Year },
                {"Director", movieJsonLittleMermaid.Director },
                {"Genre", movieJsonLittleMermaid.Genre },
                {"Actors", movieJsonLittleMermaid.Actors },
                {"Plot", movieJsonLittleMermaid.Plot },
                {"Poster", movieJsonLittleMermaid.Poster }
            };

            return movieDataLittleMermaid;

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
