using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Anime
{
    internal static class Anime
    {
        internal static async Task<AnimeByNameModel> GetAnimeAsync(string name, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/anime?filter[text]={name}");
            var anime = JsonConvert.DeserializeObject<AnimeByNameModel>(json);
            return anime;
        }
        
        internal static async Task<AnimeByNameModel> GetAnimeAsync(string name, int offset, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/anime?filter[text]={name}&page[offset]={offset}");
            var anime = JsonConvert.DeserializeObject<AnimeByNameModel>(json);
            return anime;
        }
        
        internal static async Task<AnimeByIdModel> GetAnimeAsync(int id, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/anime/{id}");
            var anime = JsonConvert.DeserializeObject<AnimeByIdModel>(json);
            return anime;
        }
    }
}