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
        optionList.Add("Array Test")          '4

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
                Case "4"
                    Dim a() As Integer = New Integer() {1, 2, 3}
                    Console.WriteLine(a.Count)
                    Console.WriteLine(a.Length)


                    For index = 0 To a.Length - 1
                        Console.WriteLine(a(index))
                    Next
                    Console.WriteLine("end")
                Case "exit"
                    canExecute = False
                Case Else
            End Select
        End While

        Console.WriteLine()

    End Sub
    Shared Sub SayHello()

        'Console.WriteLine(CalculateAverage(1, 2, 3, 4, 5, 6, 7))

        Dim lst001 As List(Of String) = New List(Of String)
        'lst001.Add("aaa")
        'lst001.Add("bbb")
        'lst001.Add("ccc")
        lst001.AddRange({"aaa", "bbb", "ccc"})
        Console.WriteLine("aaa:{0}, ddd:{1}", lst001.IndexOf("bbb"), lst001.IndexOf("ddd"))

        If lst001.IndexOf("aaa") <> -1 Then
            Console.WriteLine("aaaaaaaaaaaaa")
        End If




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

    Protected Shared Function CalculateAverage(ParamArray Values As Double())
        If Values.Length = 0 Then
            Return 0
        End If

        Dim sum As Double = 0
        For index = 0 To Values.Length - 1
            sum = sum + Values(index)
        Next
        Return sum / Values.Length
    End Function

    Protected Shared Sub EnterLogData(ByVal msg As String, Optional owner As String = "Boss")
        Console.WriteLine("Message is {0}, Owner is {1}", msg, owner)
    End Sub

    Protected Shared Function Add(ByVal x As Integer, ByVal y As Integer) As Integer
        Return x + y
    End Function

    Protected Shared Function Add(ByVal x As Long, ByVal y As Long) As Long
        Return x + y
    End Function


    Public Class User
        Public name As String
        Public age As Integer
    End Class

End Class
