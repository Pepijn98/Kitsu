using System.Collections.Generic;
// ReSharper disable UnusedMemberInSuper.Global

namespace Kitsu.Announcements
{
    public interface IAllAnnouncements
    {
        List<AnnouncementsDataModel> Data { get; }
    }

    public interface IAnnouncements
    {
        AnnouncementsDataModel Data { get; }
        AnnouncementsError[] Errors { get; }
    }
    
    public interface IAnnouncementsData
    {
        string Id { get; }
        string Type { get; }
        AnnouncementsAttributesModel Attributes { get; }
        AnnouncementsRelationshipsModel Relationships { get; }
    }
    
    public interface IAnnouncementsAttributes
    {
        string CreatedAt { get; }
        string UpdatedAt { get; }
        string Title { get; }
        string Description { get; }
        string ImageUrl { get; }
        string Link { get; }
    }

    public interface IAnnouncementsRelationships
    {
        AnnouncementsRelationshipModel User { get; }
    }
    
    public interface IAnnouncementsRelationship
    {
        AnnouncementsRelationshipLinksModel Links { get; }
    }
    
    public interface IAnnouncementsRelationshipLinks
    {
        string Self { get; }
        string Related { get; }
    }
    
    public interface IAnnouncementsError
    {
        string Title { get; }
        string Detail { get; }
        string Code { get; }
        string Status { get; }
    }
}