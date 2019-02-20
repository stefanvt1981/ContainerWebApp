using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContainerWebAppDemo.Components.PrimeCalculator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContainerWebAppDemo.Pages
{
    public class PrimeModel : PageModel
    {
        private IPrimeCalculator _calculator;
        private CancellationTokenSource _cts;

        public PrimeModel(IPrimeCalculator calculator)
        {
            _calculator = calculator;
        }

        [BindProperty]
        public int[] Primes { get; set; }

        public void OnGet()
        {
            Primes = _calculator.GetPrimes();
        }

        public ActionResult OnPostStartAsync()
        {
            _cts = new CancellationTokenSource(20000);

            _calculator.Clear();

            Task.Run(() => _calculator.Run(_cts));

            return RedirectToPage("./Prime");
        }

        public ActionResult OnPostStopAsync()
        {
            _cts.Cancel();

            return RedirectToPage("./Prime");
        }
    }
}