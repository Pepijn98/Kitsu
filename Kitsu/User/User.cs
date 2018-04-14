using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.User
{
    public static class User
    {
        /// <summary>
        /// Search for a user with either a search query, their name or slug
        /// </summary>
        /// <param name="filter">Filter type</param>
        /// <param name="text">The query, name or slug</param>
        /// <returns>List with user data objects</returns>
        public static async Task<UserModel> GetUserAsync(FilterType filter, string text)
        {
            var f = CheckType(filter);
            var json = await Kitsu.Client.GetStringAsync($"{Kitsu.BaseUri}/users?filter[{f}]={text}");
            var user = JsonConvert.DeserializeObject<UserModel>(json);
            if (user.Data.Count <= 0) { throw new NoDataFoundException($"No user was found with the {f} {text}"); }
            return user;
        }
        
        /// <summary>
        /// Search for a user with either a search query, their name or slug and page offset
        /// </summary>
        /// <param name="filter">Filter type</param>
        /// <param name="text">The query, name or slug</param>
        /// <param name="offset">Page offset</param>
        /// <returns>List with user data objects</returns>
        public static async Task<UserModel> GetUserAsync(FilterType filter, string text, int offset)
        {
            var f = CheckType(filter);
            var json = await Kitsu.Client.GetStringAsync($"{Kitsu.BaseUri}/users?filter[{f}]={text}&page[offset]={offset}");
            var user = JsonConvert.DeserializeObject<UserModel>(json);
            if (user.Data.Count <= 0) { throw new NoDataFoundException($"No user was found with the {f} {text} and offset {offset}"); }
            return user;
        }

        /// <summary>
        /// Search for a user with his/her id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Object with user data</returns>
        public static async Task<UserByIdModel> GetUserAsync(int id)
        {
            var json = await Kitsu.Client.GetStringAsync($"{Kitsu.BaseUri}/users/{id}");
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