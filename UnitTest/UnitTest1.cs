using System.Collections.Generic;
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
                @"Adam et al introduced a test.",
                    @"Adam et al.
introduced a
test.");
            Format( // et al,.は改行せず，また,が消える
                @"Adam et al introduced a test.",
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
            Format( // 1.は改行されない
                @"1. Test", @"1. Test");
            Format( // 123.は改行されない
                @"123. Test", @"123. Test");
            Format( // 1.2.は改行されない
                @"1.2. Test", @"1.2. Test");
            Format( // 1.2.3.は改行されない
                @"1.2.3. Test", @"1.2.3. Test");
            Format( // 連番
                @"1. Test.
2. Hello.
3. World.
4. Section.
4.1. Chapter.
4.1.2. Item.", @"1. Test. 2. Hello. 3. World. 4. Section. 4.1. Chapter. 4.1.2. Item.");
        }

        [TestMethod]
        public void TranslationTest()
        {
            var origList = new List<string> { "Test.", "Hello world!", "This is good." };
            var transList = new List<string> { "テスト。", "ハローワールド！", "これは良い。" };
            var pTList = BuildPTList(origList, transList);
            var trans = new Translation();
            var poTrans = new PrivateObject(trans);
            poTrans.SetField("_pTList", pTList);
            GetOrigAssert(trans, pTList);
            GetTransAssert(trans, pTList);
        }

        private static List<PTrans> BuildPTList(List<string> origList, List<string> transList)
        {
            Assert.AreEqual(origList.Count, transList.Count);
            var pTList = new List<PTrans>();
            var origPos = 0;
            var transPos = 0;
            for (var i = 0; i < origList.Count; i++)
            {
                pTList.Add(new PTrans(origPos, transPos, origList[i], transList[i]));
                origPos += origList[i].Length;
                transPos += transList[i].Length;
            }

            return pTList;
        }

        private static void GetOrigAssert(Translation trans, List<PTrans> pTList)
        {
            var x = pTList[pTList.Count - 1].OrigPos + pTList[pTList.Count - 1].OrigText.Length + 10; // 余分な長さまで確認
            var pt = trans.GetOrig(-1); // 負数を渡すと先頭を返す
            Assert.AreEqual(pTList[0].OrigText, pt.OrigText);
            Assert.AreEqual(pTList[0].TransText, pt.TransText);

            var idx = 0;
            for (var i = 0; i < x; i++)
            {
                if (i >= pTList[idx].TransPos + pTList[idx].TransText.Length)
                {
                    if (idx < pTList.Count - 1) idx++;
                }
                pt = trans.GetOrig(i);
                Assert.AreEqual(pTList[idx].OrigText, pt.OrigText);
                Assert.AreEqual(pTList[idx].TransText, pt.TransText);
            }
        }

        private static void GetTransAssert(Translation trans, List<PTrans> pTList)
        {
            var x = pTList[pTList.Count - 1].TransPos + pTList[pTList.Count - 1].TransText.Length + 10; // 余分な長さまで確認
            var pt = trans.GetTrans(-1); // 負数を渡すと先頭を返す
            Assert.AreEqual(pTList[0].OrigText, pt.OrigText);
            Assert.AreEqual(pTList[0].TransText, pt.TransText);

            var idx = 0;
            for (var i = 0; i < x; i++)
            {
                if (i >= pTList[idx].OrigPos + pTList[idx].OrigText.Length)
                {
                    if (idx < pTList.Count - 1) idx++;
                }
                pt = trans.GetTrans(i);
                Assert.AreEqual(pTList[idx].OrigText, pt.OrigText);
                Assert.AreEqual(pTList[idx].TransText, pt.TransText);
            }
        }
    }
}
