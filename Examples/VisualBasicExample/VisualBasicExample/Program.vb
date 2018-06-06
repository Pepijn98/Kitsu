Option Strict On
Imports Kitsu
Imports Kitsu.Anime
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
            Dim ani = Await Anime.GetAnimeAsync("Fate/Extra Last Encore")
            Console.WriteLine(ani.Data.Item(0).Attributes.Titles.JaJp) '=> Fate/EXTRA Last Encore
        Catch e As NoDataFoundException
            Console.WriteLine(e.Message)
        End Try
    End Function
End Class