using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kitsu.Models;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Manga
{
    public class Manga
    {
        // Search for a manga with the name
        public static async Task<MangaModelByName> GetMangaAsync(string name, int offset = 0)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", Kitsu.UserAgent);

            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/manga?filter[text]={name}&page[offset]={offset}");
            
            var manga = JsonConvert.DeserializeObject<MangaModelByName>(json);
            return manga;
        }

        // Get a manga by its id
        public static async Task<MangaModelById> GetMangaAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", Kitsu.UserAgent);

            var resp = await client.GetAsync($"https://kitsu.io/api/edge/manga/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            
            var manga = JsonConvert.DeserializeObject<MangaModelById>(json);
            return manga;
        }
    }
}