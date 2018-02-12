using System.Collections.Generic;
using Kitsu.Interfaces;
using Newtonsoft.Json;

namespace Kitsu.Models
{
    public class CharacterByNameModel : ICharacterByName
    {
        [JsonProperty("data")]
        public List<CharacterDataModel> Data { get; private set; }
    }
    
    public class CharacterByIdModel : ICharacterById
    {
        [JsonProperty("data")]
        public CharacterDataModel Data { get; private set; }

        [JsonProperty("errors")]
        public CharacterErrorModel[] Errors { get; private set; }
    }
    
    public class CharacterDataModel : ICharacterData
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        [JsonProperty("type")]
        public string Type { get; private set; }
        
        [JsonProperty("attributes")]
        public CharacterAttributesModel Attributes { get; private set; }
    }

    public class CharacterAttributesModel : ICharacterAttributes
    {
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
        
        [JsonProperty("slug")]
        public string Slug { get; private set; }
        
        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("malId")]
        public int? MalId { get; private set; }
        
        [JsonProperty("description")]
        public string Description { get; private set; }
        
        [JsonProperty("image")]
        public CharacterImageModel Image { get; private set; }
    }

    public class CharacterImageModel : ICharacterImage
    {
        [JsonProperty("original")]
        public string Original { get; private set; }
    }

    public class CharacterErrorModel : ICharacterError
    {
        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("detail")]
        public string Detail { get; private set; }

        [JsonProperty("code")]
        public string Code { get; private set; }

        [JsonProperty("status")]
        public string Status { get; private set; }
    }
}