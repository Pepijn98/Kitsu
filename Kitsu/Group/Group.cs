using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Group
{
    public static class Group
    {
        /// <summary>
        /// Search for a group with a search query
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>List with group data objects</returns>
        public static async Task<GroupByQueryModel> GetGroupAsync(string query)
        {
            var json = await Kitsu.Client.GetStringAsync($"https://kitsu.io/api/edge/groups?filter[query]={query}");
            var user = JsonConvert.DeserializeObject<GroupByQueryModel>(json);
            return user;
        }
        
        /// <summary>
        /// Search for a group with a search query and page offset
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="offset">Page offset</param>
        /// <returns>List with group data objects</returns>
        public static async Task<GroupByQueryModel> GetGroupAsync(string query, int offset)
        {
            var json = await Kitsu.Client.GetStringAsync($"https://kitsu.io/api/edge/groups?filter[query]={query}&page[offset]={offset}");
            var user = JsonConvert.DeserializeObject<GroupByQueryModel>(json);
            return user;
        }

        /// <summary>
        /// Search for a group with its id
        /// </summary>
        /// <param name="id">Group id</param>
        /// <returns>Object with group data</returns>
        public static async Task<GroupByIdModel> GetGroupAsync(int id)
        {
            var json = await Kitsu.Client.GetStringAsync($"https://kitsu.io/api/edge/groups/{id}");
            var user = JsonConvert.DeserializeObject<GroupByIdModel>(json);
            return user;
        }
    }
}