using System.Collections.Generic;
// ReSharper disable UnusedMemberInSuper.Global

namespace Kitsu.Character
{
    public interface ICharacterByName
    {
        List<CharacterDataModel> Data { get; }
    }

    public interface ICharacterById
    {
        CharacterDataModel Data { get; }
        CharacterErrorModel[] Errors { get; }
    }
    
    public interface ICharacterData
    {
        string Id { get; }
        string Type { get; }
        CharacterAttributesModel Attributes { get; }
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