using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using wan24.Core;
using wan24.I8NGUI;

BuildType build = BuildType.Browser;
#if RELEASE
build |= BuildType.Release;
#else
build |= BuildType.Debug;
#endif

var builder = WebAssemblyHostBuilder.CreateDefault(args);
await RazorStartup.StartAsync(GuiType.WASM, build, builder.Services);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddFluentUIComponents();

await builder.Build().RunAsync();
