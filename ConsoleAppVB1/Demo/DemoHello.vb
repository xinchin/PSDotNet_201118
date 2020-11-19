Public Class DemoHello
    Inherits DemoBase

    Shared Sub Run()
        Dim canExecute As Boolean = True
        Dim op As String = String.Empty

        optionList.Clear()
        optionList.Add("Hello 001")                         '0
        optionList.Add("ShowEnvironmentDetails")            '1
        optionList.Add("UseDatesAndTimes")                  '2
        optionList.Add("BasicStringFunctionality")          '3

        While canExecute
            ShowOptions()
            op = Console.ReadLine()
            Console.WriteLine()
            Console.WriteLine("Your selection is： {0}", op)
            Console.WriteLine("=========================================================")
            Console.WriteLine()
            Select Case op
                Case "0"
                    SayHello()
                Case "1"
                    ShowEnvironmentDetails()
                Case "2"
                    ShowEnvironmentDetails()
                Case "3"
                    BasicStringFunctionality()
                Case "exit"
                    canExecute = False
                Case Else
            End Select
        End While

        Console.WriteLine()

    End Sub
    Shared Sub SayHello()

        Dim v1 = 99
        Console.WriteLine(v1.GetType)

    End Sub

    Shared Sub ShowEnvironmentDetails()
        Console.WriteLine("OS：{0}", Environment.OSVersion)
    End Sub


    Shared Sub BasicStringFunctionality()
        Console.WriteLine("BasicStringFunctionality")
        Dim firstName As String = "Freddy Freddy"
        Console.WriteLine("Value of firstName : {0}", firstName)
        Console.WriteLine("after replce : {0}", firstName.Replace("dy", "**"))
        Console.WriteLine("firstName contains letter 'y' ? {0}", firstName.Contains("y"))
        Console.WriteLine("firstName : {0} {1}", firstName, Chr(7))
    End Sub

    Public Class User
        Public name As String
        Public age As Integer
    End Class

End Class
