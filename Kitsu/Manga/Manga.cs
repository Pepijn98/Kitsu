using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Manga
{
    public class Manga
    {
        private static readonly HttpClient Client = Kitsu.Client();
        
        // Search for a manga with the name
        public static async Task<MangaByNameModel> GetMangaAsync(string name, int offset = 0)
        {
            var json = await Client.GetStringAsync($"/manga?filter[text]={name}&page[offset]={offset}");
            
            var manga = JsonConvert.DeserializeObject<MangaByNameModel>(json);
            return manga;
        }

        // Get a manga by its id
        public static async Task<MangaByIdModel> GetMangaAsync(int id)
        {
            var resp = await Client.GetAsync($"/manga/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            
            var manga = JsonConvert.DeserializeObject<MangaByIdModel>(json);
            return manga;
        }
    }
}