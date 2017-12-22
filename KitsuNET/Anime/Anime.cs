using System;
using System.Threading.Tasks;
using KitsuNET.Models;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace KitsuNET.Anime
{
    public class Anime
    {
        public static async Task<AnimeModel> GetAnimeAsync(string name)
        {
            var json = await HttpReq.AnimeByNameAsync(name);
            
            try
            {
                var anime = JsonConvert.DeserializeObject<AnimeModel>(json);
                return anime;
            }
            catch (Exception e)
            {
                var err = "{'error':'" + e.Message + "'}";
                var returnThing = JsonConvert.DeserializeObject<AnimeModel>(err);
                return returnThing;
            }
        }
    }
}