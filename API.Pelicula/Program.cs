using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Microsoft.Identity.Web;
using System.Reflection;
using OpenApiInfo = Microsoft.OpenApi.Models.OpenApiInfo;
using OpenApiContact = Microsoft.OpenApi.Models.OpenApiContact;
using NSwag;
using NSwag.Generation.Processors.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
// Add services to the container.


builder.Services.AddControllers()
       .AddJsonOptions(c =>
       {
           c.JsonSerializerOptions.PropertyNamingPolicy = null;
       }
       );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Api.Peliculas",
            Description = "Métodos de API para consumir Peliculas",
            Version = "v1"
        });

    // Set the comments path for the Swagger JSON and UI.**
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});



builder.Services.AddUsuarioServices();
builder.Services.AddPeliculaServices();

//AuthCodeAAD
builder.Services.AddOpenApiDocument(document =>
{
    document.Title = "Peliculas-API";
    document.Version = "v1-Peliculas-API";
    document.DocumentName = "v1-Peliculas-API";

    //document.ApiGroupNames = OAuthFlow.ClientCredentialsAAD.GetGroupNames();
    document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));
});

var app = builder.Build();


app.UseOpenApi();
app.UseSwaggerUi3(c =>
{
    c.OAuth2Client = new NSwag.AspNetCore.OAuth2ClientSettings
    {
        AppName = "Api.Peliculas"
    };
});



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
