using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global
// ReSharper disable RedundantCaseLabel

namespace Kitsu.User
{
    public static class User
    {
        private static readonly HttpClient Client = Kitsu.Client();

        /// <summary>
        /// Search for a user with either a search query, their name or slug
        /// </summary>
        /// <param name="text">The Query, name or slug</param>
        /// <param name="filter">Filter type</param>
        /// <returns>List with user data objects</returns>
        public static async Task<UserModel> GetUserAsync(string text, FilterType filter)
        {
            var f = CheckType(filter);
            var json = await Client.GetStringAsync($"https://kitsu.io/api/edge/users?filter[{f}]={text}");
            var user = JsonConvert.DeserializeObject<UserModel>(json);
            return user;
        }
        
        /// <summary>
        /// Search for a user with either a search query, their name or slug and page offset
        /// </summary>
        /// <param name="text">The Query, name or slug</param>
        /// <param name="filter">Filter type</param>
        /// <param name="offset">Page offset</param>
        /// <returns>List with user data objects</returns>
        public static async Task<UserModel> GetUserAsync(string text, FilterType filter, int offset)
        {
            var f = CheckType(filter);
            var json = await Client.GetStringAsync($"https://kitsu.io/api/edge/users?filter[{f}]={text}&page[offset]={offset}");
            var user = JsonConvert.DeserializeObject<UserModel>(json);
            return user;
        }

        /// <summary>
        /// Search for a user with his/her id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Object with user data</returns>
        public static async Task<UserByIdModel> GetUserAsync(int id)
        {
            var resp = await Client.GetAsync($"https://kitsu.io/api/edge/users/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserByIdModel>(json);
            return user;
        }
        
        /// <summary>
        /// Convert enum FilterType to string that is usable in the request url
        /// </summary>
        /// <param name="filter">FilterType</param>
        /// <returns>Filter string</returns>
        private static string CheckType(FilterType filter)
        {
            switch (filter)
            {
                case FilterType.Slug:
                    return "slug";
                case FilterType.Query:
                    return "query";
                case FilterType.Name:
                    return "name";
                default:
                    throw new System.ArgumentException("Somehow you managed to input a non-existing FilterType");
            }
        }
    }

    public enum FilterType
    {
        Slug,
        Name,
        Query
    }
}