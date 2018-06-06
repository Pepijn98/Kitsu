using System;
using System.Threading.Tasks;
using Kitsu;
using Kitsu.Anime;

namespace CSharpExample
{
    public static class Program
    {
        public static void Main() => RunAsync().GetAwaiter().GetResult();

        private static async Task RunAsync()
        {
            // With anime id
            var anime = await Anime.GetAnimeAsync(5);
            Console.WriteLine(anime.Errors.Length >= 1
                ? $"Error: {anime.Errors[0].Code}"
                : anime.Data.Attributes.Titles.EnJp); //=> Beet the Vandel Buster
                
            // With anime name
            // Note: Searching by name returns a list of anime objects and does not have the Errors property
            // Since getting anime by name does not have the Errors property it will throw a NoDataFoundException
            try
            {
                var animes = await Anime.GetAnimeAsync("Fate/Apocrypha");
                foreach (var ani in animes.Data)
                {
                    if (ani.Attributes.Titles.EnJp != "")
                    {
                        Console.WriteLine(ani.Attributes.Titles.EnJp);
                        /* =>
                         * Fate/Apocrypha
                         * Fate/Apocrypha: Seihai Taisen Douran-hen
                         * Fate/Zero
                         * Fate/stay night: Unlimited Blade Works
                         * Fate/stay night: Unlimited Blade Works 2nd Season
                         * Fate/Zero 2nd Season
                         * Fate/Prototype
                         * Fate/stay night
                         * Ai Yori Aoshi: Enishi
                         * Bayonetta: Bloody Fate
                         */
                    }
                }
            }
            catch(NoDataFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
