Public Class DemoHello
    Inherits DemoBase

    Shared Sub Run()
        Dim canExecute As Boolean = True
        Dim op As String = String.Empty

        optionList.Add("Hello 001") '0
        optionList.Add("Hello 002") '1

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

End Class
