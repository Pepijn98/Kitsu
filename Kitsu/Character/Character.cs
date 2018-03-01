using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Character
{
    internal static class Character
    {
        internal static async Task<CharacterByNameModel> GetCharacterAsync(string name, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/characters?filter[name]={name}");
            var character = JsonConvert.DeserializeObject<CharacterByNameModel>(json);
            return character;
        }
        
        internal static async Task<CharacterByNameModel> GetCharacterAsync(string name, int offset, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/characters?filter[name]={name}&page[offset]={offset}");
            var character = JsonConvert.DeserializeObject<CharacterByNameModel>(json);
            return character;
        }

        internal static async Task<CharacterByIdModel> GetCharacterAsync(int id, HttpClient client)
        {
            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/characters/{id}");
            var character = JsonConvert.DeserializeObject<CharacterByIdModel>(json);
            return character;
        }
    }
}