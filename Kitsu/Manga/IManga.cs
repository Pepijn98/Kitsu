using System.Collections.Generic;
// ReSharper disable UnusedMemberInSuper.Global

namespace Kitsu.Manga
{
    public interface IMangaByName
    {
        List<MangaDataModel> Data { get; }
    }
    
    public interface IMangaById
    {
        MangaDataModel Data { get; }
        MangaError[] Errors { get; }
    }
    
    public interface IMangaData
    {
        string Id { get; }
        string Type { get; }
        MangaAttributesModel Attributes { get; }
    }

    public interface IMangaAttributes
    {
        string CreatedAt { get; }
        string UpdatedAt { get; }
        string Slug { get; }
        string Synopsis { get; }
        MangaTitlesModel Titles { get; }
        string CanonicalTitle { get; }
        string[] AbbreviatedTitles { get; }
        string AverageRating { get; }
        int? UserCount { get; }
        int? FavoritesCount { get; }
        string StartDate { get; }
        string EndDate { get; }
        int? PopularityRank { get; }
        int? RatingRank { get; }
        string AgeRating { get; }
        string AgeRatingGuide { get; }
        string Subtype { get; }
        string Status { get; }
        string Tba { get; }
        MangaPosterImageModel PosterImage { get; }
        MangaCoverImageModel CoverImage { get; }
        int? ChapterCount { get; }
        int? VolumeCount { get; }
        string Serialization { get; }
        string MangaType { get; }
    }
    
    public interface IMangaCoverImage
    {
        string Tiny { get; }
        string Small { get; }
        string Large { get; }
        string Original { get; }
    }
    
    public interface IMangaTitles
    {
        string En { get; }
        string EnJp { get; }
        string JaJp { get; }
    }
    
    public interface IMangaPosterImage
    {
        string Tiny { get; }
        string Small { get; }
        string Medium { get; }
        string Large { get; }
        string Original { get; }
    }

    public interface IMangaError
    {
        string Title { get; }
        string Detail { get; }
        string Code { get; }
        string Status { get; }
    }
}