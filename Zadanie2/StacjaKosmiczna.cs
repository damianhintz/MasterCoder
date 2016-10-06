using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containers
{
    public class StacjaKosmiczna : IContainers
    {
        int _potrzebneKontenery; //najmniejsza liczba potrzebnych kontenerów
                                 //int[] _sumyPośrednie;

        public new static IContainers GetInstance()
        {
            return new StacjaKosmiczna();
        }

        public override int countCombinations(int fuelVolume, List<int> containers)
        {
            if (fuelVolume <= 0) return 0;
            if (containers == null) return 0;
            if (containers.Count == 0) return 0;
            for (int i = 0; i < containers.Count; i++)
            {
                if (containers[i] == fuelVolume)
                {
                    return 1; //optymalizacja dla jednego kontenera
                }
            }
            //sortowanie kontenerów malejąco
            var posortowaneKontenery = containers
                .OrderByDescending(c => c)
                .ToArray();
            //_sumyPośrednie = new int[containers.Count];
            //for (int i = posortowaneKontenery.Length - 2; i >= 0; i--) _sumyPośrednie[i] = _sumyPośrednie[i + 1] + posortowaneKontenery[i + 1];
            _potrzebneKontenery = posortowaneKontenery.Length + 1;
            subsets(
                paliwo: fuelVolume,
                index: 0,
                kontenery: posortowaneKontenery,
                count: 0);
            return _potrzebneKontenery > posortowaneKontenery.Length ?
                0 : //nie znaleziono takiej kombinacji kontenerów, która pozwoli zabrać paliwo
                _potrzebneKontenery;
        }

        void subsets(int paliwo, int index, int[] kontenery, int count)
        {
            if (paliwo == 0)
            {
                if (count < _potrzebneKontenery)
                {
                    _potrzebneKontenery = count; //nowa kombinacja kontenerów jest lepsza
                }
                return; //znaleźliśmy kombinację kontenerów, która pozwoli zabrać paliwo
            }
            for (int i = index; i < kontenery.Length; i++)
            {
                int pojemnośćKontenera = kontenery[i];
                if (pojemnośćKontenera > paliwo) continue; //kontener jest za duży
                //if (_sumyPośrednie[i] < paliwo - pojemnośćKontenera) return;
                subsets(paliwo - pojemnośćKontenera, i + 1, kontenery, count + 1);
            }
        }
    }
}
