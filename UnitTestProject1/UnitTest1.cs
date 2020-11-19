using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            string expectiveValue = "Hello";

            //Act
            WindowsFormsApp1.Demo.DemoHelloForm frm = new WindowsFormsApp1.Demo.DemoHelloForm();
            string actualValue = frm.SayHello();

            //Assert
            Assert.AreEqual(expectiveValue, actualValue);

        }
    }
}
