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
        public void test_czy_zadanie9_przykład_paczki()
        {
            var z9 = CardParser.GetInstance();
            var listener = new ParserListener();
            z9.setParserListener(listener);
            var buffer =
                "BEGIN:VCARD\r\n" +
                "N:Jan Kowalski\r\n" +
                "PHOTO:oijasdcokmasodijcocmoijasdcokmasodIjcocmoijasdcokmasodijcocmoijasdcokmasodijco\r\n" +
                "asodijcocmoijasdcokmasodijcocmoijasdcokmasOdijcocmoijasdcokmasodijcocmoijasdco\r\n" +
                "asodijcocmoijasdcokYYJrr\r\n" +
                "\r\n" +
                "TEL:696 969 696\r\n" +
                "ADR:ul.Dowborczykow 25, 90 - 993 Lodz\r\n" +
                "EMAIL:jan.kowalski @cybercom.com\r\n" +
                "END:VCAR";
            var bufferChars = buffer.ToCharArray();
            foreach (var c in bufferChars)
            {
                var status = z9.parse(c.ToString());
                Assert.AreEqual(
                    expected: ParseStatus.PARSE_STATUS_MORE_DATA,
                    actual: status, message: "char: " + c);
                Assert.AreEqual(expected: 0, actual: listener.Count());
            }
        }

        [TestMethod]
        public void test_czy_zadanie9_przykład()
        {
            var z9 = CardParser.GetInstance();
            var listener = new ParserListener();
            z9.setParserListener(listener);
            var status = z9.parse(buffer:
                "BEGIN:VCARD\r\n" +
                "N:Jan Kowalski\r\n" +
                "PHOTO:oijasdcokmasodijcocmoijasdcokmasodIjcocmoijasdcokmasodijcocmoijasdcokmasodijco\r\n" +
                "asodijcocmoijasdcokmasodijcocmoijasdcokmasOdijcocmoijasdcokmasodijcocmoijasdco\r\n" +
                "asodijcocmoijasdcokYYJrr\r\n" +
                "\r\n" +
                "TEL:696 969 696\r\n" +
                "ADR:ul.Dowborczykow 25, 90 - 993 Lodz\r\n" +
                "EMAIL:jan.kowalski @cybercom.com\r\n" +
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
            var listener = new ParserListener();
            z9.setParserListener(listener);
            var status = z9.parse(buffer:
                "BEGIN:VCARD\r\n" +
                "N:Jan Kowalski\r\n" +
                "PHOTO:\r\n" +
                "\r\n" +
                "TEL:696 969 696\r\n" +
                "ADR:ul.Dowborczykow 25, 90 - 993 Lodz\r\n" +
                "EMAIL:jan.kowalski @cybercom.com\r\n" +
                "END:VCARDBEGIN:VCARD"
                );
            Assert.AreEqual(
                expected: ParseStatus.PARSE_STATUS_MORE_DATA,
                actual: status);
            Assert.AreEqual(expected: 1, actual: listener.Count());
            var card = listener.First();
            Assert.AreEqual("Jan Kowalski", card.Name);
            Assert.AreEqual("", card.PhotoData);
            Assert.AreEqual("696 969 696", card.TelNumber);
            Assert.AreEqual("ul.Dowborczykow 25, 90 - 993 Lodz", card.Address);
            Assert.AreEqual("jan.kowalski @cybercom.com", card.Email);
        }

        [TestMethod]
        public void test_czy_zadanie9_error()
        {
            var z9 = CardParser.GetInstance();
            var listener = new ParserListener();
            z9.setParserListener(listener);
            var status = z9.parse(buffer:
                "BEGIN:VCARD\r\n" +
                "N:Jan Kowalski\r\n" +
                "PHOTO:\r\n" +
                "\r\n" +
                "TEL:696 969 696\r\n" +
                "ADR:ul.Dowborczykow 25, 90 - 993 Lodz\r\n" +
                "EMAIL:jan.kowalski @cybercom.com\r\n" +
                "END:VCARDX"
                );
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
            var listener = new ParserListener();
            z9.setParserListener(listener);
            var status = z9.parse(buffer);
            Assert.AreEqual(
                expected: ParseStatus.PARSE_STATUS_MORE_DATA,
                actual: status);
            Assert.AreEqual(expected: 0, actual: listener.Count());
        }

        [TestMethod]
        public void test_czy_zadanie9_vCard1()
        {
            var fileName = Path.Combine(@"..\..\Samples", "vCard1.txt");
            var buffer = File.ReadAllText(fileName, Encoding.GetEncoding(1250));
            var z9 = CardParser.GetInstance();
            var listener = new ParserListener();
            z9.setParserListener(listener);
            var status = z9.parse(buffer);
            Assert.AreEqual(
                expected: ParseStatus.PARSE_STATUS_OK,
                actual: status);
            Assert.AreEqual(expected: 1, actual: listener.Count());
        }

        [TestMethod]
        public void test_czy_zadanie9_vCard2()
        {
            var fileName = Path.Combine(@"..\..\Samples", "vCard2.txt");
            var buffer = File.ReadAllText(fileName, Encoding.GetEncoding(1250));
            var z9 = CardParser.GetInstance();
            var listener = new ParserListener();
            z9.setParserListener(listener);
            var status = z9.parse(buffer);
            Assert.AreEqual(
                expected: ParseStatus.PARSE_STATUS_OK,
                actual: status);
            Assert.AreEqual(expected: 2, actual: listener.Count());
        }

        [TestMethod]
        public void test_czy_zadanie9_vCard2ab()
        {
            var fileName = Path.Combine(@"..\..\Samples", "vCard2a.txt");
            var buffer = File.ReadAllText(fileName, Encoding.GetEncoding(1250));
            var z9 = CardParser.GetInstance();
            var listener = new ParserListener();
            z9.setParserListener(listener);
            var status = z9.parse(buffer);
            Assert.AreEqual(
                expected: ParseStatus.PARSE_STATUS_MORE_DATA,
                actual: status);
            Assert.AreEqual(expected: 0, actual: listener.Count());
            fileName = Path.Combine(@"..\..\Samples", "vCard2b.txt");
            buffer = File.ReadAllText(fileName, Encoding.GetEncoding(1250));
            status = z9.parse(buffer);
            Assert.AreEqual(
                expected: ParseStatus.PARSE_STATUS_OK,
                actual: status);
            Assert.AreEqual(expected: 2, actual: listener.Count());
        }
    }
}
