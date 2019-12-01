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
            var form = new Form1();
            Assert.AreEqual($@"test", form.Format("test"));
        }
    }
}
