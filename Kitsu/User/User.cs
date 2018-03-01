using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global
// ReSharper disable RedundantCaseLabel

namespace Kitsu.User
{
    internal static class User
    {
        internal static async Task<UserModel> GetUserAsync(FilterType filter, string text, HttpClient client)
        {
            var f = CheckType(filter);
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/users?filter[{f}]={text}");
            var user = JsonConvert.DeserializeObject<UserModel>(json);
            return user;
        }
        
        internal static async Task<UserModel> GetUserAsync(FilterType filter, string text, int offset, HttpClient client)
        {
            var f = CheckType(filter);
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/users?filter[{f}]={text}&page[offset]={offset}");
            var user = JsonConvert.DeserializeObject<UserModel>(json);
            return user;
        }
        
        internal static async Task<UserByIdModel> GetUserAsync(int id, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/users/{id}");
            var user = JsonConvert.DeserializeObject<UserByIdModel>(json);
            return user;
        }
        
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