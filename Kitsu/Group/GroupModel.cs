using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kitsu.Group
{
    public class GroupByQueryModel : IGroupByQuery
    {
        [JsonProperty("data")]
        public List<GroupDataModel> Data { get; private set; }
    }
    
    public class GroupByIdModel : IGroupById
    {
        [JsonProperty("data")]
        public GroupDataModel Data { get; private set; }
        
        [JsonProperty("errors")]
        public GroupError[] Errors { get; private set; } = { };
    }
    
    public class GroupDataModel : IGroupData
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        [JsonProperty("type")]
        public string Type { get; private set; }
        
        [JsonProperty("attributes")]
        public GroupAttributesModel Attributes { get; private set; }
        
        [JsonProperty("relationships")]
        public GroupRelationshipsModel Relationships { get; private set; }
    }

    public class GroupAttributesModel : IGroupAttributes
    {
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
        
        [JsonProperty("slug")]
        public string Slug { get; private set; }
        
        [JsonProperty("about")]
        public string About { get; private set; }
        
        [JsonProperty("locale")]
        public string Locale { get; private set; }
        
        [JsonProperty("membersCount")]
        public int? Members { get; private set; }
        
        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("nsfw")]
        public bool Nsfw { get; private set; }
        
        [JsonProperty("privacy")]
        public string Privacy { get; private set; }
        
        [JsonProperty("rules")]
        public string Rules { get; private set; }
        
        [JsonProperty("rulesFormatted")]
        public string RulesFormatted { get; private set; }
        
        [JsonProperty("leadersCount")]
        public int? Leaders { get; private set; }
        
        [JsonProperty("neighborsCount")]
        public int? Neighbors { get; private set; }
        
        [JsonProperty("features")]
        public bool Features { get; private set; }
        
        [JsonProperty("tagline")]
        public string Tagline { get; private set; }
        
        [JsonProperty("lastActivityAt")]
        public string LastActivityAt { get; private set; }
        
        [JsonProperty("avatar")]
        public GroupAvatarModel Avatar { get; private set; }
        
        [JsonProperty("coverImage")]
        public GroupCoverImageModel CoverImage { get; private set; }
    }

    public class GroupAvatarModel : IGroupAvatar
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

    public class GroupCoverImageModel : IGroupCoverImage
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
    
    public class GroupRelationshipsModel : IGroupRelationships
    {
        [JsonProperty("members")]
        public GroupRelationshipModel Members { get; private set; }
        
        [JsonProperty("neighbors")]
        public GroupRelationshipModel Neighbors { get; private set; }
        
        [JsonProperty("tickets")]
        public GroupRelationshipModel Tickets { get; private set; }
        
        [JsonProperty("invites")]
        public GroupRelationshipModel Invites { get; private set; }
        
        [JsonProperty("reports")]
        public GroupRelationshipModel Reports { get; private set; }
        
        [JsonProperty("leaderChatMessages")]
        public GroupRelationshipModel LeaderChatMessages { get; private set; }
        
        [JsonProperty("actionLogs")]
        public GroupRelationshipModel ActionLogs { get; private set; }
        
        [JsonProperty("category")]
        public GroupRelationshipModel Category { get; private set; }
        
        [JsonProperty("pinnedPost")]
        public GroupRelationshipModel PinnedPost { get; private set; }
    }
    
    public class GroupRelationshipModel : IGroupRelationship
    {
        [JsonProperty("links")]
        public GroupRelationshipLinksModel Links { get; private set; }
    }

    public class GroupRelationshipLinksModel : IGroupRelationshipLinks
    {
        [JsonProperty("self")]
        public string Self { get; private set; }
        
        [JsonProperty("related")]
        public string Related { get; private set; }
    }

    public class GroupError : IGroupError
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