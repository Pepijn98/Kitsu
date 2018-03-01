[![Build status](https://ci.appveyor.com/api/projects/status/2ot3sf9evxcpdc8s?svg=true)](https://ci.appveyor.com/project/KurozeroPB/kitsu)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/5b00c0d297934281ae9ecdd6155ac2f9)](https://www.codacy.com/app/KurozeroPB/Kitsu?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=KurozeroPB/Kitsu&amp;utm_campaign=Badge_Grade)

[![NuGet](https://img.shields.io/nuget/vpre/Kitsu.svg)](https://www.nuget.org/packages/Kitsu)
[![NuGet](https://img.shields.io/nuget/v/Kitsu.svg)](https://www.nuget.org/packages/Kitsu)

# Kitsu
A kitsu api wrapper written in C# .NET Core

## Example
**.NET Core ConsoleApplication:**
```cs
using System;
using System.Threading.Tasks;
using Kitsu.Anime;

namespace KitsuTest
{
    public class Program
    {
        public static void Main() => new Program().RunAsync().GetAwaiter().GetResult();

        private async Task RunAsync()
        {
            // With anime id
            var anime = await Anime.GetAnimeAsync(5);
            Console.WriteLine(anime.Errors.Length >= 1
                ? $"Error: {anime.Errors[0].Code}"
                : anime.Data.Attributes.Titles.EnJp); //=> Beet the Vandel Buster
                
            // With anime name
            // Note: Searching by name returns a list of anime objects and does not have the Errors property
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
    }
}
```

### TODO
* ~~Support getting users~~
* ~~Support searching for groups using query filter~~
* ~~Support fetching trending anime,manga~~
* ~~Support getting site annoucements~~
* Support getting producers data
* Support getting dramas by name and id + trending dramas
