using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Manga
{
    public static class Manga
    {
        private static readonly HttpClient Client = Kitsu.Client();
        
        // Search for a manga with the name
        public static async Task<MangaByNameModel> GetMangaAsync(string name)
        {
            var json = await Client.GetStringAsync($"https://kitsu.io/api/edge/manga?filter[text]={name}");
            
            var manga = JsonConvert.DeserializeObject<MangaByNameModel>(json);
            return manga;
        }
        
        // Search for a manga with the name and page offset
        public static async Task<MangaByNameModel> GetMangaAsync(string name, int offset)
        {
            var json = await Client.GetStringAsync($"https://kitsu.io/api/edge/manga?filter[text]={name}&page[offset]={offset}");
            
            var manga = JsonConvert.DeserializeObject<MangaByNameModel>(json);
            return manga;
        }

        // Get a manga by its id
        public static async Task<MangaByIdModel> GetMangaAsync(int id)
        {
            var resp = await Client.GetAsync($"https://kitsu.io/api/edge/manga/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            
            var manga = JsonConvert.DeserializeObject<MangaByIdModel>(json);
            return manga;
        }
    }
}