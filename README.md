[![NuGet](https://img.shields.io/nuget/v/Kitsu.svg)](https://www.nuget.org/packages/Kitsu)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/5b00c0d297934281ae9ecdd6155ac2f9)](https://www.codacy.com/app/KurozeroPB/Kitsu?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=KurozeroPB/Kitsu&amp;utm_campaign=Badge_Grade)

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
            // Also has a string overload for getting anime by name
            // Note: the string overload doesn't have an Errors property since kitsu doesn't return errors properly when searching by name
            var anime = await Anime.GetAnimeAsync(5);

            // Logs the anime title if there are no errors
            Console.WriteLine(anime.Errors.Length >= 1
                ? $"Error: {anime.Errors[0].Code}"
                : anime.Data.Attributes.Titles.EnJp);
        }
    }
}
```

### TODO
* ~~Support getting users~~ <!-- https://kitsu.docs.apiary.io/#reference/users/users -->
* Support searching for groups using query filter <!-- https://kitsu.io/api/edge/groups?filter[query]=<USER_QUERY> -->
* Support fetching trending anime,manga,drama <!-- https://kitsu.docs.apiary.io/#reference/media/trending-anime/fetch-collection -->
* Support getting site annoucements <!-- https://kitsu.docs.apiary.io/#reference/site-announcements/site-announcements -->
* Support getting producers data <!-- -->
* Support getting dramas by name and id <!-- -->
