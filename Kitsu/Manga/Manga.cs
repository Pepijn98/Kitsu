using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Manga
{
    internal static class Manga
    {
        internal static async Task<MangaByNameModel> GetMangaAsync(string name, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/manga?filter[text]={name}");
            var manga = JsonConvert.DeserializeObject<MangaByNameModel>(json);
            return manga;
        }
        
        internal static async Task<MangaByNameModel> GetMangaAsync(string name, int offset, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/manga?filter[text]={name}&page[offset]={offset}");
            var manga = JsonConvert.DeserializeObject<MangaByNameModel>(json);
            return manga;
        }
        
        internal static async Task<MangaByIdModel> GetMangaAsync(int id, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/manga/{id}");
            var manga = JsonConvert.DeserializeObject<MangaByIdModel>(json);
            return manga;
        }
    }
}