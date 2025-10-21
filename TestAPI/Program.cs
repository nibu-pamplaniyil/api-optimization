using Microsoft.EntityFrameworkCore;
using TestAPI.Components;
using TestAPI.Data;
using TestAPI.Repositories;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();



builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true; 
    options.Providers.Add<GzipCompressionProvider>(); 
    options.Providers.Add<BrotliCompressionProvider>(); 
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = System.IO.Compression.CompressionLevel.Fastest;
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = System.IO.Compression.CompressionLevel.Fastest;
});

builder.Services.AddDbContext<ApplicationDbContext>(optionsAction =>
{
    optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7016/")
});




builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseResponseCompression();
app.MapControllers();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
