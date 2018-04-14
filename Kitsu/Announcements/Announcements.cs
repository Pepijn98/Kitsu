using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Announcements
{
    public class Announcements
    {
        /// <summary>
        /// Get all the site announcements
        /// </summary>
        /// <returns>List with announcements data objects</returns>
        /// <exception cref="NoDataFoundException"></exception>
        public static async Task<AllAnnouncementsModel> GetAnnouncementsAsync()
        {
            var json = await Kitsu.Client.GetStringAsync($"{Kitsu.BaseUri}/site-announcements");
            var announcements = JsonConvert.DeserializeObject<AllAnnouncementsModel>(json);
            if (announcements.Data.Count <= 0) throw new NoDataFoundException("Could not find any announcements");
            return announcements;
        }
        
        /// <summary>
        /// Get a site annoucement with a specific id
        /// </summary>
        /// <param name="id">Announcement id</param>
        /// <returns>Object with announcement data</returns>
        public static async Task<AnnouncementsModel> GetAnnouncementAsync(int id)
        {
            var json = await Kitsu.Client.GetStringAsync($"{Kitsu.BaseUri}/site-announcements/{id}");
            var announcements = JsonConvert.DeserializeObject<AnnouncementsModel>(json);
            return announcements;
        }
    }
}