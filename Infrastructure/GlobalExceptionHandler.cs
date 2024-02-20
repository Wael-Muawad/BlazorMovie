using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorMovie.Infrastructure
{
    public class GlobalExceptionHandler : ErrorBoundary//: IExceptionHandler
    {
        [Inject]
        private IWebAssemblyHostEnvironment _hostEnvironment { get; set; }

        protected override Task OnErrorAsync(Exception exception)
        {
            if (_hostEnvironment.IsDevelopment())
            {
                return base.OnErrorAsync(exception);
            }

            return Task.CompletedTask;
        }
    }
}
