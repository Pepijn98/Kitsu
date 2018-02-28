using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kitsu.User
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
        public object Relationships { get; private set; }
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
        public object WaifuModel { get; private set; }
        
        [JsonProperty("husbando")]
        public object HusbandoModel { get; private set; }
        
        [JsonProperty("pinnedPosts")]
        public object PinnedPostModel { get; private set; }
        
        [JsonProperty("followers")]
        public object FollowersModel { get; private set; }
        
        [JsonProperty("following")]
        public object FollowingModel { get; private set; }
        
        [JsonProperty("blocks")]
        public object BlocksModel { get; private set; }
        
        [JsonProperty("linkedAccounts")]
        public object LinkedAccountsModel { get; private set; }
        
        [JsonProperty("profileLinks")]
        public object ProfileLinksModel { get; private set; }
        
        [JsonProperty("userRoles")]
        public object UserRolesModel { get; private set; }
        
        [JsonProperty("libraryEntries")]
        public object LibraryEntriesModel { get; private set; }
        
        [JsonProperty("favorites")]
        public object FavoritesModel { get; private set; }
        
        [JsonProperty("reviews")]
        public object ReviewsModel { get; private set; }
        
        [JsonProperty("stats")]
        public object StatsModel { get; private set; }
        
        [JsonProperty("notificationSettings")]
        public object NotificationSettingsModel { get; private set; }
        
        [JsonProperty("oneSignalPlayers")]
        public object OneSignalPlayersModel { get; private set; }
    }
    
    // Start Relationships //

    public class WaifuModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }

    public class HusbandoModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }

    public class PinnedPostModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    public class FollowersModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    public class FollowingModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    public class BlocksModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    public class LinkedAccountsModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    public class ProfileLinksModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    public class UserRolesModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    public class LibraryEntriesModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    public class FavoritesModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    public class ReviewsModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    public class StatsModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    public class NotificationSettingsModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    public class OneSignalPlayersModel : IUserRelationship
    {
        [JsonProperty("links")]
        public object UserRelationshipLinksModel { get; private set; }
    }
    
    // End Relationships //

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