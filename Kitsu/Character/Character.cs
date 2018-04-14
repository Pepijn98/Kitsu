using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Character
{
    public static class Character
    {
        /// <summary>
        /// Search for a character with his/her name
        /// </summary>
        /// <param name="name">Character name</param>
        /// <returns>List with character data objects</returns>
        /// <exception cref="NoDataFoundException"></exception>
        public static async Task<CharacterByNameModel> GetCharacterAsync(string name)
        {
            var json = await Kitsu.Client.GetStringAsync($"{Kitsu.BaseUri}/characters?filter[name]={name}");
            var character = JsonConvert.DeserializeObject<CharacterByNameModel>(json);
            if (character.Data.Count <= 0) throw new NoDataFoundException($"No character was found with the name {name}");
            return character;
        }
        
        /// <summary>
        /// Search for a character with his/her name and page offset
        /// </summary>
        /// <param name="name">Character name</param>
        /// <param name="offset">Page offset</param>
        /// <returns>List with character data objects</returns>
        /// <exception cref="NoDataFoundException"></exception>
        public static async Task<CharacterByNameModel> GetCharacterAsync(string name, int offset)
        {
            var json = await Kitsu.Client.GetStringAsync($"{Kitsu.BaseUri}/characters?filter[name]={name}&page[offset]={offset}");
            var character = JsonConvert.DeserializeObject<CharacterByNameModel>(json);
            if (character.Data.Count <= 0) throw new NoDataFoundException($"No character was found with the name {name} and offset {offset}");
            return character;
        }

        /// <summary>
        /// Search for a character with his/her id
        /// </summary>
        /// <param name="id">Character id</param>
        /// <returns>Object with character data</returns>
        public static async Task<CharacterByIdModel> GetCharacterAsync(int id)
        {
            var json = await Kitsu.Client.GetStringAsync($"{Kitsu.BaseUri}/characters/{id}");
            var character = JsonConvert.DeserializeObject<CharacterByIdModel>(json);
            return character;
        }
    }
}