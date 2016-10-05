using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containers
{
    public class StacjaKosmiczna : IContainers
    {
        public override int countCombinations(int fuelVolume, List<int> containers)
        {
            var kontenery = containers
                .OrderByDescending(c => c)
                .ToArray();
            var paliwo = fuelVolume;
            for(int i = 0; i < kontenery.Count(); i++)
            {
                var kontener = kontenery[i];
                if (kontener < paliwo)
                {
                    paliwo -= kontener;
                }
            }
            throw new NotImplementedException();
        }
    }
}
