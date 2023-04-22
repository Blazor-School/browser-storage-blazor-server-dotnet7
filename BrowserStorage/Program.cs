using BrowserStorage.Utilities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<CacheStorageAccessor>();
builder.Services.AddScoped<CookieStorageAccessor>();
builder.Services.AddScoped<IndexedDbAccessor>();
builder.Services.AddScoped<LocalStorageAccessor>();
builder.Services.AddScoped<MemoryStorageUtility>();
builder.Services.AddScoped<SessionStorageAccessor>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:3091") });

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
