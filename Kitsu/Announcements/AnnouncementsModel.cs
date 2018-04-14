using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kitsu.Announcements
{
    public class AllAnnouncementsModel : IAllAnnouncements
    {
        [JsonProperty("data")]
        public List<AnnouncementsDataModel> Data { get; private set; }
    }
    
    public class AnnouncementsModel : IAnnouncements
    {
        [JsonProperty("data")]
        public AnnouncementsDataModel Data { get; private set; }
        
        [JsonProperty("errors")]
        public AnnouncementsError[] Errors { get; private set; }
    }
    
    public class AnnouncementsDataModel : IAnnouncementsData
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        [JsonProperty("type")]
        public string Type { get; private set; }
        
        [JsonProperty("attributes")]
        public AnnouncementsAttributesModel Attributes { get; private set; }
        
        [JsonProperty("relationships")]
        public AnnouncementsRelationshipsModel Relationships { get; private set; }
    }

    public class AnnouncementsAttributesModel : IAnnouncementsAttributes
    {
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
        
        [JsonProperty("title")]
        public string Title { get; private set; }
        
        [JsonProperty("description")]
        public string Description { get; private set; }
        
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; private set; }
        
        [JsonProperty("link")]
        public string Link { get; private set; }
    }

    public class AnnouncementsRelationshipsModel : IAnnouncementsRelationships
    {
        [JsonProperty("user")]
        public AnnouncementsRelationshipModel User { get; private set; }
    }
    
    public class AnnouncementsRelationshipModel : IAnnouncementsRelationship
    {
        [JsonProperty("links")]
        public AnnouncementsRelationshipLinksModel Links { get; private set; }
    }
    
    public class AnnouncementsRelationshipLinksModel : IAnnouncementsRelationshipLinks
    {
        [JsonProperty("self")]
        public string Self { get; private set; }
        
        [JsonProperty("related")]
        public string Related { get; private set; }
    }
    
    public class AnnouncementsError : IAnnouncementsError
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