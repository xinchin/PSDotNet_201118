Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()

        'Arrange
        Dim expectiveValue = "Hello"

        'Act
        Dim frm As New WindowsAppVB1.DemoHelloForm
        Dim actualValue = frm.SayHello()

        'Assert
        Assert.AreEqual(expectiveValue, actualValue)



    End Sub

End Class