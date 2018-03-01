using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using _Anime = Kitsu.Anime.Anime;
using _Character = Kitsu.Character.Character;
using _Group = Kitsu.Group.Group;
using _Manga = Kitsu.Manga.Manga;
using _User = Kitsu.User.User;
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ConvertToConstant.Global
// ReSharper disable UnusedLocalFunction


namespace Kitsu
{
    public class Kitsu
    {
        public static readonly string Version = "1.2.0-alpha3";
        private static readonly string UserAgent = $"Kitsu/v{Version} NugetPackage (https://github.com/KurozeroPB/Kitsu)";
        
        public Kitsu()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            // Anime
            async Task<AnimeByNameModel> SearchAnime(string name, int offset = 0)
            {
                if (offset >= 1) return await _Anime.GetAnimeAsync(name, offset, client);
                return await _Anime.GetAnimeAsync(name, client);
            }
            async Task<AnimeByIdModel> GetAnime(int id) => await _Anime.GetAnimeAsync(id, client);
            
            // Character
            async Task<CharacterByNameModel> SearchCharacter(string name, int offset = 0)
            {
                if (offset >= 1) return await _Character.GetCharacterAsync(name, offset, client);
                return await _Character.GetCharacterAsync(name, client);
            }
            async Task<CharacterByIdModel> GetCharacter(int id) => await _Character.GetCharacterAsync(id, client);
            
            // Group
            async Task<GroupByQueryModel> SearchGroup(string name, int offset = 0)
            {
                if (offset >= 1) return await _Group.GetGroupAsync(name, offset, client);
                return await _Group.GetGroupAsync(name, client);
            }
            async Task<GroupByIdModel> GetGroup(int id) => await _Group.GetGroupAsync(id, client);
            
            // Manga
            async Task<MangaByNameModel> SearchManga(string name, int offset = 0)
            {
                if (offset >= 1) return await _Manga.GetMangaAsync(name, offset, client);
                return await _Manga.GetMangaAsync(name, client);
            }
            async Task<MangaByIdModel> GetManga(int id) => await _Manga.GetMangaAsync(id, client);
            
            // User
            async Task<UserModel> SearchUser(User.FilterType filter, string name, int offset = 0)
            {
                if (offset >= 1) return await _User.GetUserAsync(filter, name, offset, client);
                return await _User.GetUserAsync(filter, name, client);
            }
            async Task<UserByIdModel> GetUser(int id) => await _User.GetUserAsync(id, client);
        }
    }
}
