using System.Net.Http;
using System.Threading.Tasks;
using Kitsu.Models;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Manga
{
    public class Manga
    {
        private readonly HttpClient _client = Kitsu.Client();
        
        // Search for a manga with the name
        public async Task<MangaModelByName> GetMangaAsync(string name, int offset = 0)
        {
            var json = await _client.GetStringAsync($"https://kitsu.io/api/edge/manga?filter[text]={name}&page[offset]={offset}");
            
            var manga = JsonConvert.DeserializeObject<MangaModelByName>(json);
            return manga;
        }

        // Get a manga by its id
        public async Task<MangaModelById> GetMangaAsync(int id)
        {
            var resp = await _client.GetAsync($"https://kitsu.io/api/edge/manga/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            
            var manga = JsonConvert.DeserializeObject<MangaModelById>(json);
            return manga;
        }
    }
}