using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyDistributor
{
    public abstract class IFrequencyDistributor
    {
        protected static IFrequencyDistributor m_frequencyDistributorInstance;
        
        public static IFrequencyDistributor GetInstance()
        {
            // m_frequencyDistributorInstance = new ...;
            // return m_frequencyDistributorInstance;
            throw new NotImplementedException();
        }

        public abstract List<int> distribute(uint dimA, uint dimB, List<int> frequencies, uint minDiff);

    }

}