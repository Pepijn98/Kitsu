using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Group
{
    internal static class Group
    {
        internal static async Task<GroupByQueryModel> GetGroupAsync(string query, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/groups?filter[query]={query}");
            var user = JsonConvert.DeserializeObject<GroupByQueryModel>(json);
            return user;
        }
        
        internal static async Task<GroupByQueryModel> GetGroupAsync(string query, int offset, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/groups?filter[query]={query}&page[offset]={offset}");
            var user = JsonConvert.DeserializeObject<GroupByQueryModel>(json);
            return user;
        }

        internal static async Task<GroupByIdModel> GetGroupAsync(int id, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/groups/{id}");
            var user = JsonConvert.DeserializeObject<GroupByIdModel>(json);
            return user;
        }
    }
}