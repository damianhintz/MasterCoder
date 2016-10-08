using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialTrailingZeros
{
    public abstract class IFactorialTrailingZeros
    {
        /// <summary>
        /// Put implementation creating your derived class instance in derived class source code file.
        /// Use the 'new' keyword to overwrite default behaviour.
        /// </summary>
        /// <returns></returns>
        public static IFactorialTrailingZeros GetInstance()
        {
            /* TO DO - create your object */
            // factorialInstance = new ...;
            // return factorialInstance;
            throw new NotImplementedException();
        }

        public abstract int CalculateCount(int number, int b);

        protected static IFactorialTrailingZeros factorialInstance;
    }
}
