using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KitsuNET.Models;
using Newtonsoft.Json;

namespace KitsuNET
{
    public class Anime
    {
        private const string UserAgent = "KitsuNET - (https://github.com/KurozeroPB/KitsuNET)";
        
        public static async Task<AnimeModel> GetAnimeAsync(string name)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            var stringTask = client.GetStringAsync($"https://kitsu.io/api/edge/anime?filter[text]={name}&page[offset]=0");
            var json = await stringTask;

            try
            {
                var anime = JsonConvert.DeserializeObject<AnimeModel>(json);
                return anime;
            }
            catch (Exception e)
            {
                var err = "{'error':'"+ e.Message +"'}";
                var returnThing = JsonConvert.DeserializeObject<AnimeModel>(err);
                return returnThing;
            }
        }
    }
}