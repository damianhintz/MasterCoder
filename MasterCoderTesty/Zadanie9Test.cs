using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser;

namespace MasterCoderTesty
{
    [TestClass]
    public class Zadanie9Test
    {
        [TestMethod]
        public void test_czy_zadanie9_przykład()
        {
            var z9 = CardParser.GetInstance();
            var listener = new ParserListener();
            z9.setParserListener(listener);
            var status = z9.parse(buffer:
                "BEGIN:VCARD\n" +
                "N:Jan Kowalski\n" +
                "PHOTO: oijasdcokmasodijcocmoijasdcokmasodIjcocmoijasdcokmasodijcocmoijasdcokmasodijco\n" +
                "asodijcocmoijasdcokmasodijcocmoijasdcokmasOdijcocmoijasdcokmasodijcocmoijasdco\n" +
                "asodijcocmoijasdcokYYJrr\n" +
                "\n" +
                "TEL:696 969 696\n" +
                "ADR:ul.Dowborczykow 25, 90 - 993 Lodz\n" +
                "EMAIL:jan.kowalski @cybercom.com\n" +
                "END:VCARD"
                );
            Assert.AreEqual(
                expected: ParseStatus.PARSE_STATUS_OK,
                actual: status);
            Assert.AreEqual(expected: 1, actual: listener.Count());
            var card = listener.First();
            Assert.AreEqual("Jan Kowalski", card.Name);
            Assert.AreEqual(
                "oijasdcokmasodijcocmoijasdcokmasodIjcocmoijasdcokmasodijcocmoijasdcokmasodijcoasodijcocmoijasdcokmasodijcocmoijasdcokmasOdijcocmoijasdcokmasodijcocmoijasdcoasodijcocmoijasdcokYYJrr",
                card.PhotoData);
            Assert.AreEqual("696 969 696", card.TelNumber);
            Assert.AreEqual("ul.Dowborczykow 25, 90 - 993 Lodz", card.Address);
            Assert.AreEqual("jan.kowalski @cybercom.com", card.Email);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void test_czy_zadanie9_parser_listener()
        {
            var z9 = CardParser.GetInstance();
            z9.setParserListener(listener: null);
            Assert.Fail();
        }

        [TestMethod]
        public void test_czy_zadanie9_more_data()
        {
            var z9 = CardParser.GetInstance();
            var status = z9.parse(buffer: null);
            Assert.AreEqual(
                expected: ParseStatus.PARSE_STATUS_MORE_DATA,
                actual: status);
        }

        [TestMethod]
        public void test_czy_zadanie9_error()
        {
            var z9 = CardParser.GetInstance();
            var status = z9.parse(buffer: null);
            Assert.AreEqual(
                expected: ParseStatus.PARSE_STATUS_ERROR,
                actual: status);
        }

        [TestMethod]
        public void test_czy_zadanie9_vCard0()
        {
            var fileName = Path.Combine(@"..\..\Samples", "vCard0.txt");
            var buffer = File.ReadAllText(fileName, Encoding.GetEncoding(1250));
            var z9 = CardParser.GetInstance();
            var status = z9.parse(buffer);
            Assert.AreEqual(
                expected: ParseStatus.PARSE_STATUS_ERROR,
                actual: status);
        }

        [TestMethod]
        public void test_czy_zadanie9_vCard1()
        {
            var fileName = Path.Combine(@"..\..\Samples", "vCard1.txt");
            var buffer = File.ReadAllText(fileName, Encoding.GetEncoding(1250));
            var z9 = CardParser.GetInstance();
            z9.setParserListener(listener: null);
            var status = z9.parse(buffer);
            Assert.AreEqual(
                expected: ParseStatus.PARSE_STATUS_ERROR,
                actual: status);
        }
    }
}
