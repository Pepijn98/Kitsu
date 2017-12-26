using System.Net.Http;
using System.Threading.Tasks;
using Kitsu.Models;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Character
{
    public class Character
    {
        private readonly HttpClient _client = Kitsu.Client();
        
        // Search for a character with his/her name
        public async Task<CharacterModelByName> GetCharacterAsync(string name)
        {
            var json = await _client.GetStringAsync($"https://kitsu.io/api/edge/characters?filter[name]={name}");
            
            var character = JsonConvert.DeserializeObject<CharacterModelByName>(json);
            return character;
        }

        // Search for a character with his/her id
        public async Task<CharacterModelById> GetCharacterAsync(int id)
        {
            var resp = await _client.GetAsync($"https://kitsu.io/api/edge/characters/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            
            var character = JsonConvert.DeserializeObject<CharacterModelById>(json);
            return character;
        }
    }
}