using System.Collections.Generic;
using KitsuNET.Models;
// ReSharper disable UnusedMemberInSuper.Global

namespace KitsuNET.Interfaces
{
    public interface IAnime
    {
        List<AnimeDataModule> Data { get; set; }
        string Error { get; set; }
    }
    
    public interface IAnimeData
    {
        string Id { get; set; }
        string Type { get; set; }
        AnimeAttributesModule Attributes { get; set; }
    }

    public interface IAnimeAttributes
    {
        string Tba { get; set; }
        string[] AbbreviatedTitles { get; set; }
        string AverageRating { get; set; }
        string Status { get; set; }
        string AgeRating { get; set; }
        string Subtype { get; set; }
        string CanonicalTitle { get; set; }
        int? EpisodeLength { get; set; }
        AnimeCoverImageModule CoverImage { get; set; }
        AnimeTitlesModule Titles { get; set; }
        string AgeRatingGuide { get; set; }
        string StartDate { get; set; }
        int? EpisodeCount { get; set; }
        int? FavoritesCount { get; set; }
        bool Nsfw { get; set; }
        string EndDate { get; set; }
        int? RatingRank { get; set; }
        AnimePosterImageModule AnimePoster { get; set; }
        string Synopsis { get; set; }
        string ShowType { get; set; }
        int? UserCount { get; set; }
        int? PopularityRank { get; set; }
    }

    public interface IAnimeCoverImage
    {
        string Original { get; set; }
        string Tiny { get; set; }
        string Small { get; set; }
        string Large { get; set; }
    }
    
    public interface IAnimeTitles
    {
        string EnJp { get; set; }
        string JaJp { get; set; }
    }
    
    public interface IAnimePosterImage
    {
        string Tiny { get; set; }
        string Small { get; set; }
        string Medium { get; set; }
        string Large { get; set; }
        string Original { get; set; }
    }
}