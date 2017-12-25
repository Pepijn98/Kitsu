using System.Collections.Generic;
using Kitsu.Interfaces;
using Newtonsoft.Json;

namespace Kitsu.Models
{
    public class MangaModelByName : IMangaByName
    {
        [JsonProperty("data")]
        public List<MangaDataModel> Data { get; private set; }
    }
    
    public class MangaModelById : IMangaById
    {
        [JsonProperty("data")]
        public MangaDataModel Data { get; private set; }
        
        [JsonProperty("errors")]
        public MangaError[] Errors { get; private set; } = { };
    }
    
    public class MangaDataModel : IMangaData
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        [JsonProperty("type")]
        public string Type { get; private set; }
        
        [JsonProperty("attributes")]
        public MangaAttributesModel Attributes { get; private set; }
    }

    public class MangaAttributesModel : IMangaAttributes
    {
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
        
        [JsonProperty("slug")]
        public string Slug { get; private set; }
        
        [JsonProperty("synopsis")]
        public string Synopsis { get; private set; }
        
        [JsonProperty("titles")]
        public MangaTitlesModel Titles { get; private set; }
        
        [JsonProperty("canonicalTitle")]
        public string CanonicalTitle { get; private set; }
        
        [JsonProperty("abbreviatedTitles")]
        public string[] AbbreviatedTitles { get; private set; }
        
        [JsonProperty("averageRating")]
        public string AverageRating { get; private set; }
        
        [JsonProperty("userCount")]
        public int? UserCount { get; private set; }
        
        [JsonProperty("favoritesCount")]
        public int? FavoritesCount { get; private set; }
        
        [JsonProperty("startDate")]
        public string StartDate { get; private set; }
        
        [JsonProperty("endDate")]
        public string EndDate { get; private set; }
        
        [JsonProperty("popularityRank")]
        public int? PopularityRank { get; private set; }
        
        [JsonProperty("ratingRank")]
        public int? RatingRank { get; private set; }
        
        [JsonProperty("ageRating")]
        public string AgeRating { get; private set; }
        
        [JsonProperty("ageRatingGuide")]
        public string AgeRatingGuide { get; private set; }
        
        [JsonProperty("subtype")]
        public string Subtype { get; private set; }
        
        [JsonProperty("status")]
        public string Status { get; private set; }
        
        [JsonProperty("tba")]
        public string Tba { get; private set; }
        
        [JsonProperty("posterImage")]
        public MangaPosterImageModel PosterImage { get; private set; }
        
        [JsonProperty("coverImage")]
        public MangaCoverImageModel CoverImage { get; private set; }
        
        [JsonProperty("chapterCount")]
        public int? ChapterCount { get; private set; }
        
        [JsonProperty("volumeCount")]
        public int? VolumeCount { get; private set; }
        
        [JsonProperty("serialization")]
        public string Serialization { get; private set; }
        
        [JsonProperty("mangaType")]
        public string MangaType { get; private set; }
    }

    public class MangaCoverImageModel : IMangaCoverImage
    {
        [JsonProperty("tiny")]
        public string Tiny { get; private set; }
        
        [JsonProperty("small")]
        public string Small { get; private set; }
        
        [JsonProperty("large")]
        public string Large { get; private set; }
        
        [JsonProperty("original")]
        public string Original { get; private set; }
    }
    
    public class MangaTitlesModel : IMangaTitles
    {
        [JsonProperty("en")]
        public string En { get; private set; }
        
        [JsonProperty("en_jp")]
        public string EnJp { get; private set; }
        
        [JsonProperty("ja_jp")]
        public string JaJp { get; private set; }
    }
    
    public class MangaPosterImageModel : IMangaPosterImage
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

    public class MangaError : IMangaError
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