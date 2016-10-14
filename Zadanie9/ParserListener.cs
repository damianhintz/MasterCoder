using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parser
{
    public class ParserListener : IParserListener, IEnumerable<vCardStruct>
    {
        public IEnumerable<vCardStruct> Cards { get { return _cards; } }
        List<vCardStruct> _cards = new List<vCardStruct>();

        public override void newVCard(vCardStruct vCard)
        {
            if (vCard == null)
                throw new ArgumentNullException("vCard nie może być null");
            _cards.Add(vCard);
        }

        public IEnumerator<vCardStruct> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
