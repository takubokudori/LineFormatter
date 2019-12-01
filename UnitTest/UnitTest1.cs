﻿using System;
using LineFormatter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private static void Format(string expected, string actual)
        {
            Assert.AreEqual(expected, Form1.Format(actual));
        }

        [TestMethod]
        public void FormatTest()
        {
            Format(@"test", "test");
            Format(
                @"This is a test.",
                    @"This
is
a
test.");
            Format( // et al.は改行しない
                @"Adam et al. introduced a test.",
                    @"Adam et al.
introduced a
test.");
            Format( // et al,.は改行せず，また,が消える
                @"Adam et al. introduced a test.",
                    @"Adam et al,.
introduced a
test.");
            Format( // Fig.は改行しない
                @"Fig. 1 is a test.",
                    @"Fig. 1 is a test.");
            Format( // ?と!は改行する
                @"Is this the test?
Yes!",
                    @"Is this the test? Yes!");
            Format( // 隙間の無い.は改行しない
                @"1.2.3 T.E.S.T.
Good.", @"1.2.3 T.E.S.T. Good.");
        }
    }
}
