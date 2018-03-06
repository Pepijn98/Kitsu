[![Build status](https://ci.appveyor.com/api/projects/status/2ot3sf9evxcpdc8s?svg=true)](https://ci.appveyor.com/project/KurozeroPB/kitsu)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/5b00c0d297934281ae9ecdd6155ac2f9)](https://www.codacy.com/app/KurozeroPB/Kitsu?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=KurozeroPB/Kitsu&amp;utm_campaign=Badge_Grade)

[![NuGet](https://img.shields.io/nuget/vpre/Kitsu.svg)](https://www.nuget.org/packages/Kitsu)
[![NuGet](https://img.shields.io/nuget/v/Kitsu.svg)](https://www.nuget.org/packages/Kitsu)

# Kitsu
A kitsu api wrapper written in C# .NET Core

## Example
**C# .NET Core ConsoleApplication:**
```c#
using System;
using System.Threading.Tasks;
using Kitsu.Anime;

namespace KitsuExample
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
```

**VB .NET Core ConsoleApplication:**
```vb
Option Strict On
Imports Kitsu
' I never actually used VB so there might be a better way
' But this is how I think it should be

Module Program
    Sub Main()
        Dim prog As New Run()
        prog.MainAsync().GetAwaiter().GetResult()
    End Sub
End Module

Class Run
    Public Async Function MainAsync() As Task
        Try
            Dim anime = Await Kitsu.Anime.Anime.GetAnimeAsync("Fate/Extra Last Encore")
            Console.WriteLine(anime.Data.Item(0).Attributes.Synopsis)
        Catch e As NoDataFoundException
            Console.WriteLine(e.Message)
        End Try
    End Function
End Class
```

**F# .NET Core ConsoleApplication:**
```f#
open System
open System.Net
open Kitsu
open Kitsu.Anime
// Not entirely sure what the best practice is for async/await in F#
// I hope it's not too bad, never used F# either

(*
 * Can also use this snipped I found online:
 * open System.Threading.Tasks
 * type Microsoft.FSharp.Control.AsyncBuilder with
 *   member x.Bind(t:Task<'T>, f:'T -> Async<'R>) : Async<'R> = async.Bind(Async.AwaitTask t, f)
 *
 * and just do:
 * let! anime = Anime.GetAnimeAsync("Fate/stay night")
 *
 * But idk if that's a good or bad thing to do in F#
 *)

let animeAsync = async {
        try
            let! anime = Async.AwaitTask (Anime.GetAnimeAsync("Fate/stay night"))
            let animeName = anime.Data.Item(0).Attributes.Titles.EnJp
            printfn "%s" animeName //=> Fate/stay night
        with
            | :? NoDataFoundException as e -> printfn "%s" e.Message
    }

Async.RunSynchronously animeAsync
```

### TODO
* ~~Support getting users~~
* ~~Support searching for groups using query filter~~
* ~~Support fetching trending anime,manga~~
* ~~Support getting site annoucements~~
* Support getting producers data
* Support getting dramas by name and id + trending dramas
