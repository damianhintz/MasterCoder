using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    public class CardParser : IParser
    {
        IParserListener _listener;
        StringBuilder _buffer = new StringBuilder();
        int _lastUnparsedCardLine;

        public new static IParser GetInstance()
        {
            m_parserInstance = new CardParser();
            return m_parserInstance;
        }

        public override ParseStatus parse(string buffer)
        {
            //if (string.IsNullOrEmpty(buffer)) return ParseStatus.PARSE_STATUS_OK;
            _buffer.Append(buffer);
            buffer = _buffer
                .ToString()
                .Replace("\r\nEND:VCARDB", "\r\nEND:VCARD\r\nB");
            var lines = buffer.Split(
                separator: new string[] { "\r\n" },
                options: StringSplitOptions.None);
            vCardStruct card = null;
            StringBuilder photoData = null;
            var lastLine = lines.Last();
            var wholeLastLine =
                buffer.EndsWith("\r\n") ||
                buffer.EndsWith("\r\nEND:VCARD");
            var minusOne = wholeLastLine ? 0 : -1;
            var length = lines.Length + minusOne;
            for (int i = _lastUnparsedCardLine; i < length; i++)
            {
                var line = lines[i];
                if (line.Equals("BEGIN:VCARD"))
                {
                    card = new vCardStruct();
                    _lastUnparsedCardLine = i;
                }
                else if (line.StartsWith("N:"))
                {
                    if (card == null) throw new InvalidOperationException();
                    card.Name = line.Substring(2);
                }
                else if (line.StartsWith("PHOTO:"))
                {
                    photoData = new StringBuilder();
                    photoData.Append(line.Substring(6));
                }
                else if (line.Equals(""))
                {
                    if (photoData != null) card.PhotoData = photoData.ToString();
                    photoData = null;
                }
                else if (line.StartsWith("TEL:"))
                {
                    card.TelNumber = line.Substring(4);
                }
                else if (line.StartsWith("ADR:"))
                {
                    card.Address = line.Substring(4);
                }
                else if (line.StartsWith("EMAIL:"))
                {
                    card.Email = line.Substring(6);
                }
                else if (line.Equals("END:VCARD"))
                {
                    _listener.newVCard(card);
                    _lastUnparsedCardLine = i + 1;
                    card = null;
                    photoData = null;
                }
                else
                {
                    if (photoData != null) photoData.Append(line);
                    else
                    {
                        if (card != null) return ParseStatus.PARSE_STATUS_MORE_DATA;
                    }
                }
            }
            return card == null &&
                (_lastUnparsedCardLine >= lines.Length || string.IsNullOrEmpty(lines.Last())) ?
                ParseStatus.PARSE_STATUS_OK :
                ParseStatus.PARSE_STATUS_MORE_DATA;
        }

        public override void setParserListener(IParserListener listener)
        {
            if (listener == null) throw new ArgumentNullException("Parser listener nie może być null");
            _listener = listener;
        }
    }
}
