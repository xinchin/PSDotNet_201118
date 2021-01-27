
Public Class DemoHello
    Inherits DemoBase

    Shared Sub Run()
        Dim canExecute As Boolean = True
        Dim op As String = String.Empty
        Console.Clear()
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
            Console.WriteLine(LineString)
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
        Console.Clear()
        Console.WriteLine(LineString)
        Console.WriteLine("hello.....")

        Dim a As Integer = 9
        Dim obj As Object = a
        Dim b As Integer = CType(obj, Integer)
        Console.WriteLine(b.ToString)



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

    Public Class User
        Implements IComparable
        Public name As String
        Public age As Integer

        Public Sub New(name As String, age As Integer)
            Me.name = name
            Me.age = age
        End Sub

        Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
            'Throw New NotImplementedException()
            Dim u2 As User = CType(obj, User)
            'Return Me.age.CompareTo(u2.age)
            Return Me.name.CompareTo(u2.name)
        End Function
    End Class

    Public Class BaseType
        Private _name As String
        Public Overridable Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property


    End Class

    Public Class DerivedType
        Inherits BaseType
        Private _name As String
        Public Overrides Property Name() As String
            Get
                Return MyBase.Name
            End Get
            Set(ByVal value As String)
                If String.IsNullOrEmpty(value) Then
                    Throw New ArgumentException("null or empty")
                End If
                MyBase.Name = value
            End Set
        End Property
    End Class




End Class
