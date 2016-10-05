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
    public class WizardClass
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
            /* string[] movieList = { "wizard+of+oz", "braveheart" };
             var input = "";
             for (var i = 0; i < movieList.Length; i++)
             {
                 input = movieList[0];
                 input = movieList[1];
             } */
            var input = "wizard+of+oz";
            var clientWizard = new RestClient("http://www.omdbapi.com/");
            var requestWizard = new RestRequest("?t=" + input + "&y=&plot=short&r.json", Method.GET);
            var responseWizard = new RestResponse();
            Task.Run(async () =>
            {
                responseWizard = await GetResponseContentAsync(clientWizard, requestWizard) as RestResponse;
            }).Wait();
            WizardClass movieJsonWizard = JsonConvert.DeserializeObject<WizardClass>(responseWizard.Content);
            Dictionary<string, string> movieDataWizard = new Dictionary<string, string>()
            {
                {"Title", movieJsonWizard.Title },
                {"Year", movieJsonWizard.Year },
                {"Director", movieJsonWizard.Director },
                {"Genre", movieJsonWizard.Genre },
                {"Actors", movieJsonWizard.Actors },
                {"Plot", movieJsonWizard.Plot },
                {"Poster", movieJsonWizard.Poster }
            };

            return movieDataWizard;

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
