using System.Net.Http;
using System.Threading.Tasks;
using Kitsu.Models;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Character
{
    public class Character
    {
        private static readonly HttpClient Client = Kitsu.Client();
        
        // Search for a character with his/her name
        public static async Task<CharacterByNameModel> GetCharacterAsync(string name)
        {
            var json = await Client.GetStringAsync($"https://kitsu.io/api/edge/characters?filter[name]={name}");
            
            var character = JsonConvert.DeserializeObject<CharacterByNameModel>(json);
            return character;
        }

        // Search for a character with his/her id
        public static async Task<CharacterByIdModel> GetCharacterAsync(int id)
        {
            var resp = await Client.GetAsync($"https://kitsu.io/api/edge/characters/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            
            var character = JsonConvert.DeserializeObject<CharacterByIdModel>(json);
            return character;
        }
    }
}