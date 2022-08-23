using tareaBase.Modelo;

using Microsoft.EntityFrameworkCore; // is a modern object-database mapper for .NET.
using Microsoft.Extensions.DependencyInjection;
using tareaBase.Data; // access to data
var builder = WebApplication.CreateBuilder(args); // Initializes a new instance of the WebApplicationBuilder class with preconfigured defaults.

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<tareaBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("tareaBaseContext") ?? throw new InvalidOperationException("Connection string 'tareaBaseContext' not found.")));

var app = builder.Build(); // is a creational design pattern that allows you to build complex objects step by step.

/**
 * Encargada de inicializar la semilla en la aplicacion web
 * */
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // it's used to redirect HTTP requests to HTTPS.
app.UseStaticFiles(); // enables static files to be served:

app.UseRouting(); // adds route matching to the middleware pipeline.
                  // This middleware looks at the set of endpoints defined in the app,
                  // and selects the best match based on the request.

app.UseAuthorization(); // enables authorization capabilities.

app.MapRazorPages(); // allow an ASP.NET Core Web Application to render Razor pages.

app.Run(); // runs the program



  
// tutorial-https://docs.microsoft.com/en-us/aspnet/core/tutorials/choose-web-ui?view=aspnetcore-6.0
 

