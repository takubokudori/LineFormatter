using System;
using LineFormatter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FormatTest()
        {
            Assert.AreEqual($@"test", Form1.Format("test"));
        }
    }
}
