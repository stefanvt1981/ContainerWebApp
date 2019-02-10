using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ContainerWebAppDemo.Components.PrimeCalculator
{
    public class PrimeCalculator : IPrimeCalculator
    {
        public PrimeCalculator()
        {
            _results = new List<int>();
        }

        private List<int> _results;
        

        public Task Run(CancellationTokenSource token)
        {
            
            int number = _results.Any() ? _results.Max() : 1;
            
            while(!token.IsCancellationRequested)
            {
                int ctr = 0;

                for (int i = 2; i <= number / 2; i++)
                {
                    if (number % i == 0)
                    {
                        ctr++;
                        break;
                    }
                }

                if (ctr == 0 && number != 1)
                {
                    _results.Add(number);
                }
                
            }

            return Task.CompletedTask;
        }

        public void Clear()
        {
            _results.Clear();
        }

        public int[] GetPrimes()
        {
            return _results.ToArray();
        }

    }
}
