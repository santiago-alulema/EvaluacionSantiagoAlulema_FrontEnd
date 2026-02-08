using EvaluacionSantiagoAlulema_Front.Components;
using EvaluacionSantiagoAlulema_Front.Components.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("ApiClient", (sp, client) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var baseUrl = config["ApiSettings:BaseUrl"];

    if (string.IsNullOrWhiteSpace(baseUrl))
        throw new InvalidOperationException("Falta ApiSettings:BaseUrl en appsettings.json");

    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddScoped<TitlesApi>();
builder.Services.AddScoped<UsersApi>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
