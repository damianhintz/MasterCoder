﻿using System;
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
            for (int i = 0, j = 1; j < values.Count; j++)
            {
                var profit = values[j] - values[i];
                if (profit > maxProfit)
                {
                    leftIndex = i;
                    rightIndex = j;
                    maxProfit = profit;
                }
                if (profit < 0) i = j;
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
