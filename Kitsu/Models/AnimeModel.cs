using System.Collections.Generic;
using Kitsu.Interfaces;
using Newtonsoft.Json;

namespace Kitsu.Models
{
    public class AnimeModelByName : IAnimeByName
    {
        [JsonProperty("data")]
        public List<AnimeDataModel> Data { get; private set; }
        
        [JsonProperty("errors")]
        public List<AnimeError> Errors { get; private set; }
    }
    
    public class AnimeModelById : IAnimeById
    {
        [JsonProperty("data")]
        public AnimeDataModel Data { get; private set; }
        
        [JsonProperty("errors")]
        public List<AnimeError> Errors { get; private set; }
    }
    
    public class AnimeDataModel : IAnimeData
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        [JsonProperty("type")]
        public string Type { get; private set; }
        
        [JsonProperty("attributes")]
        public AnimeAttributesModel Attributes { get; private set; }
    }

    public class AnimeAttributesModel : IAnimeAttributes
    {
        [JsonProperty("tba")]
        public string Tba { get; private set; }
            
        [JsonProperty("abbreviatedTitles")]
        public string[] AbbreviatedTitles { get; private set; }
            
        [JsonProperty("averageRating")]
        public string AverageRating { get; private set; }
            
        [JsonProperty("status")]
        public string Status { get; private set; }
            
        [JsonProperty("ageRating")]
        public string AgeRating { get; private set; }
            
        [JsonProperty("subtype")]
        public string Subtype { get; private set; }
            
        [JsonProperty("canonicalTitle")]
        public string CanonicalTitle { get; private set; }
            
        [JsonProperty("episodeLength")]
        public int? EpisodeLength { get; private set; }
        
        [JsonProperty("coverImage")]
        public AnimeCoverImageModel CoverImage { get; private set; }
        
        [JsonProperty("slug")]
        public string Slug { get; private set; }
        
        [JsonProperty("titles")]
        public AnimeTitlesModel Titles { get; private set; }
    
        [JsonProperty("ageRatingGuide")]
        public string AgeRatingGuide { get; private set; }
            
        [JsonProperty("startDate")]
        public string StartDate { get; private set; }
            
        [JsonProperty("episodeCount")]
        public int? EpisodeCount { get; private set; }
            
        [JsonProperty("favoritesCount")]
        public int? FavoritesCount { get; private set; }
            
        [JsonProperty("nsfw")]
        public bool Nsfw { get; private set; }
            
        [JsonProperty("endDate")]
        public string EndDate { get; private set; }
            
        [JsonProperty("ratingRank")]
        public int? RatingRank { get; private set; }
            
        [JsonProperty("posterImage")]
        public AnimePosterImageModel AnimePoster { get; private set; }
        
        [JsonProperty("synopsis")]
        public string Synopsis { get; private set; }
            
        [JsonProperty("showType")]
        public string ShowType { get; private set; }
            
        [JsonProperty("userCount")]
        public int? UserCount { get; private set; }
            
        [JsonProperty("popularityRank")]
        public int? PopularityRank { get; private set; }
    }

    public class AnimeCoverImageModel : IAnimeCoverImage
    {
        [JsonProperty("original")]
        public string Original { get; private set; }
            
        [JsonProperty("tiny")]
        public string Tiny { get; private set; }
            
        [JsonProperty("small")]
        public string Small { get; private set; }
            
        [JsonProperty("large")]
        public string Large { get; private set; }
    }
    
    public class AnimeTitlesModel : IAnimeTitles
    {
        [JsonProperty("en_jp")]
        public string EnJp { get; private set; }
            
        [JsonProperty("ja_jp")]
        public string JaJp { get; private set; }
    }
    
    public class AnimePosterImageModel : IAnimePosterImage
    { 
        [JsonProperty("tiny")]
        public string Tiny { get; private set; }
            
        [JsonProperty("small")]
        public string Small { get; private set; }
        
        [JsonProperty("medium")]
        public string Medium { get; private set; }
            
        [JsonProperty("large")]
        public string Large { get; private set; }
        
        [JsonProperty("original")]
        public string Original { get; private set; }
    }

    public class AnimeError : IAnimeError
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