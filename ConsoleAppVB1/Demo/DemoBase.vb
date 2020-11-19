Public Class DemoBase
    Protected Shared optionList As New List(Of String)

    Shared Sub ShowOptions()

        Console.WriteLine("=========================================================")
        Console.WriteLine()

        For i = 0 To optionList.Count - 1
            Console.Write("{0}. {1}" & vbTab & vbTab, i, optionList(i).ToString())
            If ((i + 1) Mod 3 = 0) Then Console.WriteLine()
        Next

        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("please type 'exit' if you want to exit here")
        Console.WriteLine()
        Console.Write("Please type your selection :")

    End Sub

End Class
