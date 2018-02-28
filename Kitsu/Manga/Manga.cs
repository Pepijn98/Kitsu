using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Manga
{
    public static class Manga
    {
        private static readonly HttpClient Client = Kitsu.Client();
        
        /// <summary>
        /// Search for a manga with the name
        /// </summary>
        /// <param name="name">Manga name</param>
        /// <returns>List with manga data objects</returns>
        public static async Task<MangaByNameModel> GetMangaAsync(string name)
        {
            var json = await Client.GetStringAsync($"https://kitsu.io/api/edge/manga?filter[text]={name}");
            
            var manga = JsonConvert.DeserializeObject<MangaByNameModel>(json);
            return manga;
        }
        
        /// <summary>
        /// Search for a manga with the name and page offset
        /// </summary>
        /// <param name="name">Manga name</param>
        /// <param name="offset">Page offset</param>
        /// <returns>List with manga data objects</returns>
        public static async Task<MangaByNameModel> GetMangaAsync(string name, int offset)
        {
            var json = await Client.GetStringAsync($"https://kitsu.io/api/edge/manga?filter[text]={name}&page[offset]={offset}");
            
            var manga = JsonConvert.DeserializeObject<MangaByNameModel>(json);
            return manga;
        }

        /// <summary>
        /// Search for a manga with its id
        /// </summary>
        /// <param name="id">Manga id</param>
        /// <returns>Object with manga data</returns>
        public static async Task<MangaByIdModel> GetMangaAsync(int id)
        {
            var resp = await Client.GetAsync($"https://kitsu.io/api/edge/manga/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            
            var manga = JsonConvert.DeserializeObject<MangaByIdModel>(json);
            return manga;
        }
    }
}