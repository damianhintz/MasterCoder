﻿using System;
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
            buffer = _buffer.ToString();
            var lines = buffer.Split(
                separator: new string[] { "\r\n" },
                options: StringSplitOptions.None);
            vCardStruct card = null;
            StringBuilder photoData = null;
            for (int i = _lastUnparsedCardLine; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line.Equals("BEGIN:VCARD"))
                {
                    card = new vCardStruct();
                    _lastUnparsedCardLine = i;
                }
                else if (line.StartsWith("N:"))
                {
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
                else if (line.Equals("END:VCARDBEGIN:VCARD"))
                {
                    if (card != null) _listener.newVCard(card);
                    card = new vCardStruct();
                    _lastUnparsedCardLine = i;
                } else
                {
                    if (photoData != null) photoData.Append(line);
                    else
                    {
                        if (card != null) return ParseStatus.PARSE_STATUS_ERROR;
                    }
                }
            }
            return card == null ?
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
