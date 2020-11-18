Public Class DemoHello
    Shared Sub Run()
        Dim canExecute As Boolean = True
        Dim op As String = String.Empty
        While canExecute
            ShowOptions()
            op = Console.ReadLine()
            Console.WriteLine()
            Console.WriteLine("Your selection is： {0}", op)
            Console.WriteLine()
            Select Case op
                Case "0"
                    Console.WriteLine("-------------- Hello 001 ----------------")
                Case "1"
                    Console.WriteLine("-------------- Hello 002 ----------------")
                Case "exit"
                    canExecute = False
                Case Else
            End Select
        End While

        Console.WriteLine()

    End Sub

    Shared Sub ShowOptions()
        Dim optionList As New List(Of String)

        optionList.Add("Hello 001") '0
        optionList.Add("Hello 002") '1

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
