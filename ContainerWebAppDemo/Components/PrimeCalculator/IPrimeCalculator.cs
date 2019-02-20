using System.Threading;
using System.Threading.Tasks;

namespace ContainerWebAppDemo.Components.PrimeCalculator
{
    public interface IPrimeCalculator
    {
        void Clear();
        int[] GetPrimes();
        Task Run(CancellationTokenSource token);
    }
}