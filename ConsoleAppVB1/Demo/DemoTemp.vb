
Public Class DemoTemp
    Inherits DemoBase

    Shared Sub Run()
        Dim canExecute As Boolean = True
        Dim op As String = String.Empty
        Console.Clear()
        optionList.Clear()
        optionList.Add("Hello 001")                         '0

        While canExecute
            ShowOptions()
            op = Console.ReadLine()
            Console.WriteLine()
            Console.WriteLine("Your selection is： {0}", op)
            Console.WriteLine(LineString)
            Console.WriteLine()
            Select Case op
                Case "0"
                    SayHello()
                Case "exit"
                    canExecute = False
                Case Else
            End Select
        End While

        Console.WriteLine()

    End Sub
    Shared Sub SayHello()
        Console.Clear()
        Console.WriteLine(LineString)
        Console.WriteLine("hello.....")
    End Sub




End Class
