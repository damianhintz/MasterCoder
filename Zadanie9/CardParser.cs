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
        List<string> _lines = new List<string>();

        public new static IParser GetInstance()
        {
            m_parserInstance = new CardParser();
            return m_parserInstance;
        }

        public override ParseStatus parse(string buffer)
        {
            var card = new vCardStruct();
            _listener.newVCard(card);
            var lastLine = _lines.Last();
            buffer = lastLine + buffer;
            var lines = buffer.Split(
                separator: new string[] { @"\n" },
                options: StringSplitOptions.None);
            for(int i = 0; i < _lines.Count; i++)
            {
                var line = _lines[i];
                if (line.StartsWith(""))
                {

                }
            }
            return ParseStatus.PARSE_STATUS_OK;
        }

        public override void setParserListener(IParserListener listener)
        {
            if (listener == null) throw new ArgumentNullException("Parser listener nie może być null");
            _listener = listener;
        }
    }
}
