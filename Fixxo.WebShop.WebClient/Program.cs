using Fixxo.WebShop.WebClient;
using Fixxo.WebShop.WebClient.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5158/") });
builder.Services.AddScoped<IndexViewModel>();
builder.Services.AddScoped<ProductDetailsViewModel>();

await builder.Build().RunAsync();