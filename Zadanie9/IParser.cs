using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    public abstract class IParser
    {
		protected static IParser m_parserInstance;
        
        public static IParser GetInstance()
        {
            throw new NotImplementedException();
        }

		public abstract ParseStatus parse(String buffer);
		public abstract void setParserListener(IParserListener listener);

	}
}
