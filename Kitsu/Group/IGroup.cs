using System.Collections.Generic;
// ReSharper disable UnusedMemberInSuper.Global

namespace Kitsu.Group
{
    public interface IGroupByQuery
    {
        List<GroupDataModel> Data { get; }
    }
    
    public interface IGroupById
    {
        GroupDataModel Data { get; }
        GroupError[] Errors { get; }
    }

    public interface IGroupData
    {
        string Id { get; }
        string Type { get; }
        GroupAttributesModel Attributes { get; }
        GroupRelationshipsModel Relationships { get; }
    }

    public interface IGroupAttributes
    {
        string CreatedAt { get; }
        string UpdatedAt { get; }
        string Slug { get; }
        string About { get; }
        string Locale { get; }
        int? Members { get; }
        string Name { get; }
        bool Nsfw { get; }
        string Privacy { get; }
        string Rules { get; }
        string RulesFormatted { get; }
        int? Leaders { get; }
        int? Neighbors { get; }
        bool Features { get; }
        string Tagline { get; }
        string LastActivityAt { get; }
        GroupAvatarModel Avatar { get; }
        GroupCoverImageModel CoverImage { get; }
    }
    
    public interface IGroupAvatar
    {
        string Tiny { get; }
        string Small { get; }
        string Medium { get; }
        string Large { get; }
        string Original { get; }
    }
    
    public interface IGroupCoverImage
    {
        string Tiny { get; }
        string Small { get; }
        string Large { get; }
        string Original { get; }
    }
    
    public interface IGroupRelationships
    {
        GroupRelationshipModel Members { get; }
        GroupRelationshipModel Neighbors { get; }
        GroupRelationshipModel Tickets { get; }
        GroupRelationshipModel Invites { get; }
        GroupRelationshipModel Reports { get; }
        GroupRelationshipModel LeaderChatMessages { get; }
        GroupRelationshipModel ActionLogs { get; }
        GroupRelationshipModel Category { get; }
        GroupRelationshipModel PinnedPost { get; }
    }

    public interface IGroupRelationship
    {
        GroupRelationshipLinksModel Links { get; }
    }

    public interface IGroupRelationshipLinks
    {
        string Self { get; }
        string Related { get; }
    }
    
    public interface IGroupError
    {
        string Title { get; }
        string Detail { get; }
        string Code { get; }
        string Status { get; }
    }
}