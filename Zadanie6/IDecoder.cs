using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder
{
    public abstract class IDecoder
    {
        /// <summary>
        /// Put implementation creating your derived class instance in derived class source code file.
        /// Use the 'new' keyword to overwrite default behaviour.
        /// </summary>
        /// <returns></returns>
        public static IDecoder GetInstance()
        {
            /* TO DO - create your object */
            // decoderInstance = new ...;
            // return decoderInstance;
            throw new NotImplementedException();
        }

        public abstract Result decode(long value, string alphabet);

        protected static IDecoder decoderInstance;
    }
}
