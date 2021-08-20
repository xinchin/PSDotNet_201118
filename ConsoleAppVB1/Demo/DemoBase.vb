Public Class DemoBase
    Protected Shared optionList As New List(Of String)
    Protected Shared ReadOnly LineString As String = vbNewLine & New String("=", Console.WindowWidth) & vbNewLine

    Shared Sub ShowOptions()
        Console.WriteLine(LineString)

        For i = 0 To optionList.Count - 1
            Console.Write("{0}. {1}" & vbTab & vbTab, i, optionList(i).ToString())
            If optionList(i).Length <= 12 Then Console.Write(vbTab)
            If ((i + 1) Mod 2 = 0) Then Console.WriteLine()
        Next

        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("please type 'exit' if you want to exit here")
        Console.WriteLine()
        Console.Write("Please type your selection :")
        Console.WriteLine(LineString)

    End Sub

End Class
