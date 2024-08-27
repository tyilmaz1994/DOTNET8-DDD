using Asp.Versioning;
using Boilerplate.Api.Extensions;
using Boilerplate.Api.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

Log.Information("Starting web application");

builder.Services.AddSerilog(Log.Logger);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Boilerplate", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "Boilerplate", Version = "v2" });
});
builder.Services.AddApiVersioning(x =>
{
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.DefaultApiVersion = ApiVersion.Default;
    x.ReportApiVersions = true;
    x.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("api-version"),
        new UrlSegmentApiVersionReader()
        );
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
})
.AddMvc();
builder.Services.AddExternalServices(configuration.GetConnectionString("LibraryDb"), configuration.GetConnectionString("KafkaBrokers"));
builder.Services.AddInfraServices();
builder.Services.AddApplicationServices();
builder.Services.Configure<KafkaOptions>(configuration.GetSection("KafkaOptions"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api V1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "Api V2");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
