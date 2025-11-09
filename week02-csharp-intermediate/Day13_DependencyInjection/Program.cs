using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using day13_dependencyinjection;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Services registreren
// Transient: nieuw object bij elke aanvraag
builder.Services.AddTransient<ITransientService, TransientService>();
// Scoped: nieuw object per scope (bijv. per web request)
builder.Services.AddScoped<IScopedService, ScopedService>();
// Singleton: één object voor de hele levensduur van de applicatie
builder.Services.AddSingleton<ISingletonService, SingletonService>();

builder.Services.AddTransient<ServiceTester>();

using IHost host = builder.Build();

TestLifetime(host.Services, "Test 1");
TestLifetime(host.Services, "Test 2");

await host.RunAsync();

static void TestLifetime(IServiceProvider root, string title)
{
  Console.WriteLine($"\n=== {title} ===");

  using IServiceScope scope = root.CreateScope();
  var tester = scope.ServiceProvider.GetRequiredService<ServiceTester>();

  tester.Show();
  tester.Show(); // tweede call in dezelfde scope
}
