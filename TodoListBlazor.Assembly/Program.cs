using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoListBlazorAssembly.Service;
namespace TodoListBlazorAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddBlazoredToast();
            // Khai báo ITaskApiClient 
            builder.Services.AddTransient<ITaskAPIClient, TaskAPIClient>();
            builder.Services.AddTransient<IUsersService, UsersService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001")});

            await builder.Build().RunAsync();
        }
    }
}
