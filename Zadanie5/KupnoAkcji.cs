using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeProfit
{
    public class KupnoAkcji : IStockExchangeProfit
    {
        public new static IStockExchangeProfit GetInstance()
        {
            stockInstance = new KupnoAkcji();
            return stockInstance;
        }

        public override TaskResult FindMaxProfitRecursive(List<int> values)
        {
            var leftIndex = 0;
            var rightIndex = 1;
            var maxProfit = values[1] - values[0];
            for (int i = 0; i < values.Count - 1; i++)
            {
                var leftValue = values[i];
                for (int j = i + 1; j < values.Count; j++)
                {
                    var rightValue = values[j];
                    var profit = rightValue - leftValue;
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                        leftIndex = i;
                        rightIndex = j;
                    }
                }
            }
            return new TaskResult()
            {
                LeftIndex = leftIndex,
                RightIndex = rightIndex,
                Value = maxProfit
            };
        }
    }
}
