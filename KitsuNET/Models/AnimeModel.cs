using System.Collections.Generic;
using KitsuNET.Interfaces;
using Newtonsoft.Json;

namespace KitsuNET.Models
{
    public class AnimeModel : IAnime
    {
        [JsonProperty("data")]
        public List<AnimeDataModule> Data { get; set; }
        
        [JsonProperty("error")]
        public string Error { get; set; }
    }
    
    public class AnimeDataModule : IAnimeData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("attributes")]
        public AnimeAttributesModule Attributes { get; set; }
    }

    public class AnimeAttributesModule : IAnimeAttributes
    {
        [JsonProperty("tba")]
        public string Tba { get; set; }
            
        [JsonProperty("abbreviatedTitles")]
        public string[] AbbreviatedTitles { get; set; }
            
        [JsonProperty("averageRating")]
        public string AverageRating { get; set; }
            
        [JsonProperty("status")]
        public string Status { get; set; }
            
        [JsonProperty("ageRating")]
        public string AgeRating { get; set; }
            
        [JsonProperty("subtype")]
        public string Subtype { get; set; }
            
        [JsonProperty("canonicalTitle")]
        public string CanonicalTitle { get; set; }
            
        [JsonProperty("episodeLength")]
        public int? EpisodeLength { get; set; }
        
        [JsonProperty("coverImage")]
        public AnimeCoverImageModule CoverImage { get; set; }
        
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        [JsonProperty("titles")]
        public AnimeTitlesModule Titles { get; set; }
    
        [JsonProperty("ageRatingGuide")]
        public string AgeRatingGuide { get; set; }
            
        [JsonProperty("startDate")]
        public string StartDate { get; set; }
            
        [JsonProperty("episodeCount")]
        public int? EpisodeCount { get; set; }
            
        [JsonProperty("favoritesCount")]
        public int? FavoritesCount { get; set; }
            
        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }
            
        [JsonProperty("endDate")]
        public string EndDate { get; set; }
            
        [JsonProperty("ratingRank")]
        public int? RatingRank { get; set; }
            
        [JsonProperty("posterImage")]
        public AnimePosterImageModule AnimePoster { get; set; }
        
        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }
            
        [JsonProperty("showType")]
        public string ShowType { get; set; }
            
        [JsonProperty("userCount")]
        public int? UserCount { get; set; }
            
        [JsonProperty("popularityRank")]
        public int? PopularityRank { get; set; }
    }

    public class AnimeCoverImageModule : IAnimeCoverImage
    {
        [JsonProperty("original")]
        public string Original { get; set; }
            
        [JsonProperty("tiny")]
        public string Tiny { get; set; }
            
        [JsonProperty("small")]
        public string Small { get; set; }
            
        [JsonProperty("large")]
        public string Large { get; set; }
    }
    
    public class AnimeTitlesModule : IAnimeTitles
    {
        [JsonProperty("en_jp")]
        public string EnJp { get; set; }
            
        [JsonProperty("ja_jp")]
        public string JaJp { get; set; }
    }
    
    public class AnimePosterImageModule : IAnimePosterImage
    { 
        [JsonProperty("tiny")]
        public string Tiny { get; set; }
            
        [JsonProperty("small")]
        public string Small { get; set; }
        
        [JsonProperty("medium")]
        public string Medium { get; set; }
            
        [JsonProperty("large")]
        public string Large { get; set; }
        
        [JsonProperty("original")]
        public string Original { get; set; }
    }
}