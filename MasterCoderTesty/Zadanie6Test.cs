using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Decoder;

namespace MasterCoderTesty
{
    [TestClass]
    public class Zadanie6Test
    {
        [TestMethod]
        public void test_czy_zadanie6_28()
        {
            var a = "abcdefghijklmnopqrstuvwxyzAZ";
            var z6 = Dekoder.GetInstance();
            var codes = new[] {
                "a", "A", "z", "Z",
                "a", "b", "c", "d",
                "aa", "ab", "wa",
                "aaa", "abc",
                "abcd", "azAZ",
                "aaaaaaaaaaaa",
                "awawawawawaw",
                "ZZZZZZZZZZZZ"};
            foreach (var code in codes)
            {
                var v = Dekoder.code(code, alphabet: a);
                var r = z6.decode(v, alphabet: a);
                Assert.AreEqual(ResultCode.SUCCESS, r.CodeResult);
                Assert.AreEqual(code, r.DecodedText);
            }
        }

        [TestMethod]
        public void test_czy_zadanie6_26()
        {
            var a = "abcdefghijklmnopqrstuvwxyz";
            var z6 = Dekoder.GetInstance();
            var codes = new[] { "a", "b", "c", "d", "aa", "aaa", "ab", "abcd", "wa", "aaaaaaaaaaaa", "awawawawawaw" };
            foreach (var code in codes)
            {
                var v = Dekoder.code(code, alphabet: a);
                var r = z6.decode(v, alphabet: a);
                Assert.AreEqual(ResultCode.SUCCESS, r.CodeResult);
                Assert.AreEqual(code, r.DecodedText);
            }
        }

        [TestMethod]
        public void test_czy_zadanie6_empty()
        {
            //code("", "abcde") zwróci 3
            //decode(3, "abcde") zwróci {SUCCESS, ""} 
            var z6 = Dekoder.GetInstance();
            var r = z6.decode(3, "abcde");
            Assert.AreEqual(ResultCode.SUCCESS, r.CodeResult);
            Assert.AreEqual("", r.DecodedText);
        }

        [TestMethod]
        public void test_czy_zadanie6_przykład_success()
        {
            //code("aabc", "abcde") zwróci 2121874
            //decode(2121874, "abcde") zwróci {SUCCESS, "aabc"} 
            var z6 = Dekoder.GetInstance();
            var r = z6.decode(2121874, "abcde");
            Assert.AreEqual(ResultCode.SUCCESS, r.CodeResult);
            Assert.AreEqual("aabc", r.DecodedText);
        }

        [TestMethod]
        public void test_czy_zadanie6_przykład_fail()
        {
            //code("ddaaab", "gfedcab") zwróci 1848251554
            //decode(20, "abcde") zwróci {FAILURE, ""} 
            var z6 = Dekoder.GetInstance();
            var r = z6.decode(20, "abcde");
            Assert.AreEqual(ResultCode.FAILURE, r.CodeResult);
            Assert.AreEqual("", r.DecodedText);
        }

        [TestMethod]
        public void test_czy_zadanie6_przykład_fail_0()
        {
            //decode(0, "abcde") zwróci {FAILURE, ""} 
            var z6 = Dekoder.GetInstance();
            var r = z6.decode(0, "abcde");
            Assert.AreEqual(ResultCode.FAILURE, r.CodeResult);
            Assert.AreEqual("", r.DecodedText);
        }

        [TestMethod]
        public void test_czy_zadanie6_przykład_fail_1()
        {
            //decode(1, "abcde") zwróci {FAILURE, ""} 
            var z6 = Dekoder.GetInstance();
            var r = z6.decode(1, "abcde");
            Assert.AreEqual(ResultCode.FAILURE, r.CodeResult);
            Assert.AreEqual("", r.DecodedText);
        }

        [TestMethod]
        public void test_czy_zadanie6_przykład_fail_2()
        {
            //decode(2, "abcde") zwróci {FAILURE, ""} 
            var z6 = Dekoder.GetInstance();
            var r = z6.decode(2, "abcde");
            Assert.AreEqual(ResultCode.FAILURE, r.CodeResult);
            Assert.AreEqual("", r.DecodedText);
        }
    }
}
