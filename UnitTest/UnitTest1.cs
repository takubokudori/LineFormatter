/*
Copyright 2020 takubokudori

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
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

        private static void AssertPT(PTrans expected, PTrans actual)
        {
            Assert.AreEqual(expected.OrigPos, actual.OrigPos);
            Assert.AreEqual(expected.TransPos, actual.TransPos);
            Assert.AreEqual(expected.OrigText, actual.OrigText);
            Assert.AreEqual(expected.TransText, actual.TransText);
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
            Format(@"example.com", "example.com"); // .の後に文字が続く場合は改行しない
            Format( // e.g. i.e.は改行しない
                @"This (i.e. dog) is an animal (e.g. cat).",
                    @"This (i.e. dog) is an animal (e.g. cat).");
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
            AssertOrigTransPT(
            new List<string> { "Test.", "Hello world!", "This is good." },
            new List<string> { "テスト。", "ハローワールド！", "これは良い。" }
                );

            AssertOrigTransPT(
                new List<string> { "A", "B", "C" },
                new List<string> { "テスト。", "ハローワールド！", "これは良い。" }
            );

            AssertOrigTransPT(
            new List<string> { "Test.", "Hello world!", "This is good." },
            new List<string> { "A", "B", "C" }
                );

            AssertOrigTransPT(
                new List<string> { "Test.", "      Hello world!", "   This is good." },
                new List<string> { "A", "B", "C" }
            );

            AssertOrigTransPT(
                new List<string> { "Test.       is.          good.", "      Hello world!", "   This is good." },
                new List<string> { "A", "B", "C" }
            );
        }

        private static void AssertOrigTransPT(List<string> origList, List<string> transList)
        {
            var pTList = BuildPTList(origList, transList);
            var tt = new TranslationText("", "", pTList);
            GetOrigAssert(tt, pTList);
            GetTransAssert(tt, pTList);
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

        private static void GetOrigAssert(TranslationText trans, List<PTrans> pTList)
        {
            var x = pTList[pTList.Count - 1].OrigPos + pTList[pTList.Count - 1].OrigText.Length + 10; // 余分な長さまで確認
            var pt = trans.GetOrig(-1); // 負数を渡すと先頭を返す
            AssertPT(pTList[0], pt);

            var idx = 0;
            for (var i = 0; i < x; i++)
            {
                if (i >= pTList[idx].TransPos + pTList[idx].TransText.Length)
                {
                    if (idx < pTList.Count - 1) idx++;
                }
                pt = trans.GetOrig(i);
                AssertPT(pTList[idx], pt);
            }
        }

        private static void GetTransAssert(TranslationText trans, List<PTrans> pTList)
        {
            var x = pTList[pTList.Count - 1].TransPos + pTList[pTList.Count - 1].TransText.Length + 10; // 余分な長さまで確認
            var pt = trans.GetTrans(-1); // 負数を渡すと先頭を返す
            AssertPT(pTList[0], pt);

            var idx = 0;
            for (var i = 0; i < x; i++)
            {
                if (i >= pTList[idx].OrigPos + pTList[idx].OrigText.Length)
                {
                    if (idx < pTList.Count - 1) idx++;
                }
                pt = trans.GetTrans(i);
                AssertPT(pTList[idx], pt);
            }
        }
    }
}
