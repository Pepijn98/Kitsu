using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu
{
    public static class Manga
    {
        /// <summary>
        /// Search for a manga with the name
        /// </summary>
        /// <param name="name">Manga name</param>
        /// <returns>List with manga data objects</returns>
        public static async Task<MangaByNameModel> GetMangaAsync(string name)
        {
            var json = await Kitsu.Client.GetStringAsync($"https://kitsu.io/api/edge/manga?filter[text]={name}");
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
            var json = await Kitsu.Client.GetStringAsync($"https://kitsu.io/api/edge/manga?filter[text]={name}&page[offset]={offset}");
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
            var json = await Kitsu.Client.GetStringAsync($"https://kitsu.io/api/edge/manga/{id}");
            var manga = JsonConvert.DeserializeObject<MangaByIdModel>(json);
            return manga;
        }
    }
}