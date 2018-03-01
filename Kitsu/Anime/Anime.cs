using System.Threading.Tasks;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Kitsu.Anime
{
    public static class Anime
    {
        /// <summary>
        /// Search for an anime with the name
        /// </summary>
        /// <param name="name">Anime name</param>
        /// <returns>List with anime data objects</returns>
        public static async Task<AnimeByNameModel> GetAnimeAsync(string name)
        {
            var json = await Kitsu.Client.GetStringAsync($"anime?filter[text]={name}");
            var anime = JsonConvert.DeserializeObject<AnimeByNameModel>(json);
            if (anime.Data.Count <= 0) { throw new NoDataFoundException($"No anime was found with the name {name}"); }
            return anime;
        }
        
        /// <summary>
        /// Search for an anime with the name and page offset
        /// </summary>
        /// <param name="name">Anime name</param>
        /// <param name="offset">Page offset</param>
        /// <returns>List with anime data objects</returns>
        public static async Task<AnimeByNameModel> GetAnimeAsync(string name, int offset)
        {
            var json = await Kitsu.Client.GetStringAsync($"anime?filter[text]={name}&page[offset]={offset}");
            var anime = JsonConvert.DeserializeObject<AnimeByNameModel>(json);
            if (anime.Data.Count <= 0) { throw new NoDataFoundException($"No anime was found with the name {name} and offset {offset}"); }
            return anime;
        }

        /// <summary>
        /// Search for an anime with its id
        /// </summary>
        /// <param name="id">Anime id</param>
        /// <returns>Object with anime data</returns>
        public static async Task<AnimeByIdModel> GetAnimeAsync(int id)
        {
            var json = await Kitsu.Client.GetStringAsync($"anime/{id}");
            var anime = JsonConvert.DeserializeObject<AnimeByIdModel>(json);
            return anime;
        }

        /// <summary>
        /// Get the trending anime
        /// </summary>
        /// <returns>List with anime data objects</returns>
        public static async Task<AnimeByNameModel> GetTrendingAsync()
        {
            var json = await Kitsu.Client.GetStringAsync("trending/anime");
            var trending = JsonConvert.DeserializeObject<AnimeByNameModel>(json);
            if (trending.Data.Count <= 0) { throw new NoDataFoundException("Could not find any trending anime"); }
            return trending;
        }
    }
}