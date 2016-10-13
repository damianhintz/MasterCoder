using System;
using System.Collections.Generic;
using System.Linq;

namespace Hanoi
{
    public abstract class IHanoi
    {
        /// <summary>
        /// Pobranie liczby kr¹¿ków (która mo¿e byæ zerem).
        /// </summary>
        /// <returns></returns>
		public abstract int getNumberOfDisks();

        /// <summary>
        /// Przenoszenie kr¹¿ków.
        /// </summary>
        /// <param name="fromRod"></param>
        /// <param name="toRod"></param>
        /// <returns></returns>
		public abstract bool moveDisk(uint fromRod, uint toRod);

        /// <summary>
        /// Jaki kr¹¿ek jest na szczycie danego palika.
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
		public abstract int checkTopDisk(uint rod);
    }
}
