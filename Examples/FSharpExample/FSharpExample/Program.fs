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
            printfn "%s" (anime.Data.Item(0).Attributes.Titles.EnJp) //=> Fate/stay night
        with
            | :? NoDataFoundException as e -> printfn "%s" e.Message
    }

Async.RunSynchronously animeAsync
