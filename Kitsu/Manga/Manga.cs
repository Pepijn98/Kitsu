using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Manga
{
    public static class Manga
    {
        /// <summary>
        /// Search for a manga with the name
        /// </summary>
        /// <param name="name">Manga name</param>
        /// <returns>List with manga data objects</returns>
        /// <exception cref="NoDataFoundException"></exception>
        public static async Task<MangaByNameModel> GetMangaAsync(string name)
        {
            var json = await Kitsu.Client.GetStringAsync($"{Kitsu.BaseUri}/manga?filter[text]={name}");
            var manga = JsonConvert.DeserializeObject<MangaByNameModel>(json);
            if (manga.Data.Count <= 0) throw new NoDataFoundException($"No manga was found with the query {manga}");
            return manga;
        }
        
        /// <summary>
        /// Search for a manga with the name and page offset
        /// </summary>
        /// <param name="name">Manga name</param>
        /// <param name="offset">Page offset</param>
        /// <returns>List with manga data objects</returns>
        /// <exception cref="NoDataFoundException"></exception>
        public static async Task<MangaByNameModel> GetMangaAsync(string name, int offset)
        {
            var json = await Kitsu.Client.GetStringAsync($"{Kitsu.BaseUri}/manga?filter[text]={name}&page[offset]={offset}");
            var manga = JsonConvert.DeserializeObject<MangaByNameModel>(json);
            if (manga.Data.Count <= 0) throw new NoDataFoundException($"No manga was found with the query {manga} and offset {offset}");
            return manga;
        }

        /// <summary>
        /// Search for a manga with its id
        /// </summary>
        /// <param name="id">Manga id</param>
        /// <returns>Object with manga data</returns>
        public static async Task<MangaByIdModel> GetMangaAsync(int id)
        {
            var json = await Kitsu.Client.GetStringAsync($"{Kitsu.BaseUri}/manga/{id}");
            var manga = JsonConvert.DeserializeObject<MangaByIdModel>(json);
            return manga;
        }
        
        /// <summary>
        /// Get the trending manga
        /// </summary>
        /// <returns>List with manga data objects</returns>
        /// <exception cref="NoDataFoundException"></exception>
        public static async Task<MangaByNameModel> GetTrendingAsync()
        {
            var json = await Kitsu.Client.GetStringAsync($"{Kitsu.BaseUri}/trending/manga");
            var trending = JsonConvert.DeserializeObject<MangaByNameModel>(json);
            if (trending.Data.Count <= 0) throw new NoDataFoundException("Could not find any trending manga");
            return trending;
        }
    }
}