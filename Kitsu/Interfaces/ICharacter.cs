using Kitsu.Models;
// ReSharper disable UnusedMemberInSuper.Global

namespace Kitsu.Interfaces
{
    public interface ICharacterByName
    {
        string Id { get; }
        string Type { get; }
        CharacterAttributesModel Attributes { get; }
    }

    public interface ICharacterById
    {
        string Id { get; }
        string Type { get; }
        CharacterAttributesModel Attributes { get; }
        CharacterErrorModel[] Errors { get; }
    }

    public interface ICharacterAttributes
    {
        string CreatedAt { get; }
        string UpdatedAt { get; }
        string Slug { get; }
        string Name { get; }
        int? MalId { get; }
        string Description { get; }
        CharacterImageModel Image { get; }
    }

    public interface ICharacterImage
    {
        string Original { get; }
    }

    public interface ICharacterError
    {
        string Title { get; }
        string Detail { get; }
        string Code { get; }
        string Status { get; }
    }
}