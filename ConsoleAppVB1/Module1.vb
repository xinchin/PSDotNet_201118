Module Module1

    'Public LineString As String = New String("=", Console.WindowWidth)
    Public ReadOnly LineString As String = vbNewLine & New String("=", Console.WindowWidth) & vbNewLine

    Sub Main()
        Dim canExecute As Boolean = True
        Dim op As String = String.Empty
        While canExecute
            ShowOptions()
            op = Console.ReadLine()
            Console.WriteLine()
            Console.WriteLine("Your selection is： {0}", op)
            Console.WriteLine()
            Console.WriteLine()
            Select Case op
                Case 0
                    DemoHello.Run()
                Case 1
                    DemoAsync.Run()
                Case "exit"
                    canExecute = False
                Case Else
            End Select
        End While

        Console.WriteLine()
        Console.WriteLine("please type any key !")
        Console.ReadKey()
    End Sub

    Sub ShowOptions()
        Dim optionList As New List(Of String)

        Console.Clear()

        optionList.Add("Say Hello") '0
        optionList.Add("DemoAsync") '1

        Console.WriteLine()
        Console.WriteLine(LineString)
        For i = 0 To optionList.Count - 1
            Console.Write("{0}. {1}" & vbTab & vbTab, i, optionList(i).ToString())
            If ((i + 1) Mod 3 = 0) Then Console.WriteLine()
        Next

        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("please type 'exit' if you want to exit here")
        Console.WriteLine()
        Console.Write("Please type your selection :")
        Console.WriteLine(LineString)

    End Sub

End Module
