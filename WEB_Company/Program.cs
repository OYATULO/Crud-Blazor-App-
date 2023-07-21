using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WEB_Company;
using WEB_Company.Services;
using WEB_Company.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7280/") });
builder.Services.AddScoped<ICompanyServices, CompanyServices>();
builder.Services.AddScoped<IContactServices, ContactServices>();
builder.Services.AddScoped<IComServices, CommunicationServices>();


await builder.Build().RunAsync();
