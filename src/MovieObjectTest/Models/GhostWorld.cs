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
    public class GattacaClass
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
            var input = "gattaca";
            var clientGattaca = new RestClient("http://www.omdbapi.com/");
            var requestGattaca = new RestRequest("?t=" + input + "&y=&plot=short&r.json", Method.GET);
            var responseGattaca = new RestResponse();
            Task.Run(async () =>
            {
                responseGattaca = await GetResponseContentAsync(clientGattaca, requestGattaca) as RestResponse;
            }).Wait();
            GattacaClass movieJsonGattaca = JsonConvert.DeserializeObject<GattacaClass>(responseGattaca.Content);
            Dictionary<string, string> movieDataGattaca = new Dictionary<string, string>()
            {
                {"Title", movieJsonGattaca.Title },
                {"Year", movieJsonGattaca.Year },
                {"Director", movieJsonGattaca.Director },
                {"Genre", movieJsonGattaca.Genre },
                {"Actors", movieJsonGattaca.Actors },
                {"Plot", movieJsonGattaca.Plot },
                {"Poster", movieJsonGattaca.Poster }
            };

            return movieDataGattaca;

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
