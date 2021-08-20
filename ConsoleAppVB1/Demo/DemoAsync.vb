Public Class DemoAsync
    Inherits DemoBase
    Shared Sub Run()
        Dim canExecute As Boolean = True
        Dim op As String = String.Empty


        Console.Clear()
        optionList.Clear()
        optionList.Add("Hello 001...")              '0

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
End Class
