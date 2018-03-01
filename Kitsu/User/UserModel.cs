using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kitsu
{
    public class UserModel : IUser
    {
        [JsonProperty("data")]
        public List<UserDataModel> Data { get; private set; }
    }

    public class UserByIdModel : IUserById
    {
        [JsonProperty("data")]
        public UserDataModel Data { get; private set; }
        
        [JsonProperty("errors")]
        public UserError[] Errors { get; private set; } = { };
    }

    public class UserDataModel : IUserData
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        [JsonProperty("type")]
        public string Type { get; private set; }
        
        [JsonProperty("attributes")]
        public UserAttributesModel Attributes { get; private set; }
        
        [JsonProperty("relationships")]
        public UserRelationshipsModel Relationships { get; private set; }
    }

    public class UserAttributesModel : IUserAttributes
    {
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
        
        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("pastNames")]
        public string[] PastNames { get; private set; }
        
        [JsonProperty("slug")]
        public string Slug { get; private set; }
        
        [JsonProperty("about")]
        public string About { get; private set; }
        
        [JsonProperty("location")]
        public string Location { get; private set; }
        
        [JsonProperty("waifuOrHusbando")]
        public string WaifuOrHusbando { get; private set; }
        
        [JsonProperty("followersCount")]
        public int? Followers { get; private set; }
        
        [JsonProperty("followingCount")]
        public int? Following { get; private set; }
        
        [JsonProperty("birthday")]
        public string Birthday { get; private set; }
        
        [JsonProperty("gender")]
        public string Gender { get; private set; }
        
        [JsonProperty("commentsCount")]
        public int? Comments { get; private set; }
        
        [JsonProperty("favoritesCount")]
        public int? Favorites { get; private set; }
        
        [JsonProperty("likesGivenCount")]
        public int? LikesGiven { get; private set; }
        
        [JsonProperty("reviewsCount")]
        public int? Reviews { get; private set; }
        
        [JsonProperty("likesReceivedCount")]
        public int? LikesReceived { get; private set; }
        
        [JsonProperty("postsCount")]
        public int? Posts { get; private set; }
        
        [JsonProperty("ratingsCount")]
        public int? Ratings { get; private set; }
        
        [JsonProperty("mediaReactionsCount")]
        public int? MediaReactions { get; private set; }
        
        [JsonProperty("proExpiresAt")]
        public string ProExpiresAt { get; private set; }
        
        [JsonProperty("title")]
        public string Title { get; private set; }
        
        [JsonProperty("profileCompleted")]
        public bool ProfileCompleted { get; private set; }
        
        [JsonProperty("feedCompleted")]
        public bool FeedCompleted { get; private set; }
        
        [JsonProperty("website")]
        public string Website { get; private set; }
        
        [JsonProperty("avatar")]
        public UserAvatarModel Avatar { get; private set; }
        
        [JsonProperty("coverImage")]
        public UserCoverImageModel CoverImage { get; private set; }
        
        [JsonProperty("ratingSystem")]
        public string RatingSystem { get; private set; }
        
        [JsonProperty("theme")]
        public string Theme { get; }
        
        [JsonProperty("facebookId")]
        public string FacebookId { get; private set; }
    }

    public class UserAvatarModel : IUserAvatar
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

    public class UserCoverImageModel : IUserCoverImage
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
    
    public class UserRelationshipsModel : IUserRelationships
    {
        [JsonProperty("waifu")]
        public UserRelationshipModel Waifu { get; private set; }
        
        [JsonProperty("pinnedPosts")]
        public UserRelationshipModel PinnedPost { get; private set; }
        
        [JsonProperty("followers")]
        public UserRelationshipModel Followers { get; private set; }
        
        [JsonProperty("following")]
        public UserRelationshipModel Following { get; private set; }
        
        [JsonProperty("blocks")]
        public UserRelationshipModel Blocks { get; private set; }
        
        [JsonProperty("linkedAccounts")]
        public UserRelationshipModel LinkedAccounts { get; private set; }
        
        [JsonProperty("profileLinks")]
        public UserRelationshipModel ProfileLinks { get; private set; }
        
        [JsonProperty("userRoles")]
        public UserRelationshipModel UserRoles { get; private set; }
        
        [JsonProperty("libraryEntries")]
        public UserRelationshipModel LibraryEntries { get; private set; }
        
        [JsonProperty("favorites")]
        public UserRelationshipModel Favorites { get; private set; }
        
        [JsonProperty("reviews")]
        public UserRelationshipModel Reviews { get; private set; }
        
        [JsonProperty("stats")]
        public UserRelationshipModel Stats { get; private set; }
        
        [JsonProperty("notificationSettings")]
        public UserRelationshipModel NotificationSettings { get; private set; }
        
        [JsonProperty("oneSignalPlayers")]
        public UserRelationshipModel OneSignalPlayers { get; private set; }
    }
    
    public class UserRelationshipModel : IUserRelationship
    {
        [JsonProperty("links")]
        public UserRelationshipLinksModel Links { get; private set; }
    }

    public class UserRelationshipLinksModel : IUserRelationshipLinks
    {
        [JsonProperty("self")]
        public string Self { get; private set; }
        
        [JsonProperty("related")]
        public string Related { get; private set; }
    }

    public class UserError : IUserError
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