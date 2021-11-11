Imports System.Collections.Specialized
Imports System.Runtime.CompilerServices
Imports System.ValueType

Module Module2
    Sub Main()
        Console.WriteLine("------------ Start ----------------")

        'Dim o As Object = New User
        'Foo.myobj = o
        'Foo.myobj.Show()


        Dim f1 As New Foo(10)
        Dim f2 As Foo = f1 + 20
        Console.WriteLine(f1.myValue & vbTab & f2.myValue)


        Console.ReadKey()
        Console.WriteLine("------------ End ----------------")



    End Sub

    Public Class User
        Public Sub Show()
            Console.WriteLine("...hello show...")
        End Sub

    End Class

    Public Class Foo

        Public myValue As Integer
        Public Sub New(x As Integer)
            myValue = x
        End Sub
        Public Shared Operator +(f As Foo, x As Integer) As Foo 
            Return New Foo(f.myValue + x)
        End Operator
    End Class

End Module
