using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ScoreClient.Models
{
    public class DataClient
    {
        private string BASE_URL = "http://localhost:55641/api/";

        public IEnumerable<Leaderboard> findAllScore()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("leaderboard").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Leaderboard>>(responseData);
                }
                return null;

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Match> findAllMatch()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("match").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Match>>(responseData);
                }
                return null;

            }
            catch
            {
                return null;
            }
        }

        public Match FindMatch(int id)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("match/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Match>(responseData);
                }
                return null;

            }
            catch
            {
                return null;
            }
        }

        public bool CreateMatch(Match match)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                var myContent = JsonConvert.SerializeObject(match);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");



                HttpResponseMessage response = client.PostAsync("match", byteContent).Result;
                return response.IsSuccessStatusCode;


            }
            catch
            {
                return false;
            }
        }

        public bool Reset()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                var myContent = JsonConvert.SerializeObject("");
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");



                HttpResponseMessage response = client.PostAsync("leaderboard/reset", byteContent).Result;
                return response.IsSuccessStatusCode;


            }
            catch
            {
                return false;
            }
        }



        public bool EditMatch(Match match)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                var myContent = JsonConvert.SerializeObject(match);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");



                HttpResponseMessage response = client.PutAsync("match/" + match.MatchId, byteContent).Result;
                return response.IsSuccessStatusCode;


            }
            catch
            {
                return false;
            }
        }
    }
}
