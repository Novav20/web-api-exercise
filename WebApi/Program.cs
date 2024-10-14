using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApiRouteResponses.Context;
using WebApiRouteResponses.Middlewares;
using WebApiRouteResponses.Services;

var builder = WebApplication.CreateBuilder(args);


// Configure Services
ConfigureServices(builder);

// Build Application
var app = builder.Build();

// Configure Middleware Pipeline
ConfigureMiddleware(app);

// Start Application
app.Run();

// Method to configure services
void ConfigureServices(WebApplicationBuilder builder)
{
    // Add Controllers (without Global Authorization Policy)
    builder.Services.AddControllers()

    // This will prevent the circular reference issue
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

    // Add User Data Service
    builder.Services.AddScoped<IUserDataService, UserDataService>();

    // Configure CORS
    builder.Services.AddCors(p =>
    {
        p.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyHeader()
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .Build();
        });
    });

    // Add In-Memory Database
    builder.Services.AddDbContext<ApiDbContext>(options => options.UseInMemoryDatabase("AppDB"));

    // Get connection string from appsettings
    // var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    // Add DbContext with SQL Server
    // builder.Services.AddDbContext<ApiDbContext>(options =>
    //     options.UseSqlServer(connectionString));

    builder.Services.AddResponseCaching();

    // Add Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

// Method to configure middleware
void ConfigureMiddleware(WebApplication app)
{
    // Swagger in Development Environment
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // app.UseHttpsRedirection(); // Optionally add HTTPS redirection

    app.UseRouting(); // Enable Routing

    app.UseResponseCaching();

    app.UseCors("MyPolicy"); // Enable CORS

    // No JWT Authentication

    app.UseAuthorization(); // Authorization

    app.MapControllers(); // Map Controller Routes

    // Custom Middleware
    app.UseStatusMiddleware();

    // Optional Example Routes
    // ConfigureExampleRoutes(app);
}

// WeatherForecast Record
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
