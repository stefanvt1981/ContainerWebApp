using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContainerWebAppDemo.Extentions;
using ContainerWebAppDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ContainerWebAppDemo.Middleware
{
    public class RequestDelayerMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;
        private readonly DelayOptions _delayOptions;

        public RequestDelayerMiddleware(RequestDelegate nextRequestDelegate, IOptions<DelayOptions> delayOptions)
        {
            _nextRequestDelegate = nextRequestDelegate;
            _delayOptions = delayOptions.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            await BeginInvoke(context);
            await _nextRequestDelegate.Invoke(context);
            EndInvoke(context);
        }

        private async Task BeginInvoke(HttpContext context)
        {
            var optionsFromSession = context.Session.Get<DelayOptions>("DelayOptions");

            if(optionsFromSession == null)
            {
                optionsFromSession = _delayOptions;
            }
            if (optionsFromSession.UseDelay)
            {
                await Task.Delay(optionsFromSession.DelayInMilliseconds);
            }
        }

        private void EndInvoke(HttpContext context)
        {

        }
    }
}
