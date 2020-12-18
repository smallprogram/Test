using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Openiddicttest.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");





            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    options.ProviderOptions.ClientId = "balosar-blazor-client";
            //    options.ProviderOptions.Authority = "https://localhost:5001";
            //    options.ProviderOptions.ResponseType = "code";

            //    // Note: response_mode=fragment is the best option for a SPA. Unfortunately, the Blazor WASM
            //    // authentication stack is impacted by a bug that prevents it from correctly extracting
            //    // authorization error responses (e.g error=access_denied responses) from the URL fragment.
            //    // For more information about this bug, visit https://github.com/dotnet/aspnetcore/issues/28344.
            //    //
            //    options.ProviderOptions.ResponseMode = "query";
            //    options.AuthenticationPaths.RemoteRegisterPath = "https://localhost:5001/Identity/Account/Register";
            //    options.AuthenticationPaths.LogInPath = "https://localhost:5001/Identity/Account/Login";
            //});

            //builder.Services.AddApiAuthorization(options =>
            //{
            //    options.AuthenticationPaths.LogInPath = "https://localhost:5001/Identity/Account/Login";
            //});

            builder.Services.AddHttpClient("OIDC.ServerAPI")
                .ConfigureHttpClient(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project.
            builder.Services.AddScoped(provider =>
            {
                var factory = provider.GetRequiredService<IHttpClientFactory>();
                return factory.CreateClient("OIDC.ServerAPI");
            });

            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.ClientId = "balosar-blazor-client";
                options.ProviderOptions.Authority = "https://localhost:5001";
                options.ProviderOptions.ResponseType = "code";

                // Note: response_mode=fragment is the best option for a SPA. Unfortunately, the Blazor WASM
                // authentication stack is impacted by a bug that prevents it from correctly extracting
                // authorization error responses (e.g error=access_denied responses) from the URL fragment.
                // For more information about this bug, visit https://github.com/dotnet/aspnetcore/issues/28344.
                //
                options.ProviderOptions.ResponseMode = "query";
                options.AuthenticationPaths.RemoteRegisterPath = "https://localhost:5001/Identity/Account/Register";
                options.AuthenticationPaths.LogInPath = "https://localhost:5001/Identity/Account/Login";
            });


            await builder.Build().RunAsync();
        }
    }
}
