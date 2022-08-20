using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pottencial.Infraestructure.CrossCutting.DependencyInjection;
using Pottencial.Infraestructure.CrossCutting.JWT;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

JwtConfiguration jwtConfiguration = new();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    options.AddSecurityDefinition("JWT",
    new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization", // Authorization
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "JWT"
                }
            },
            new List<string>()
        }
    });

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Pottencial.API",
        Contact = new OpenApiContact
        {
            Name = "Michael Rozendo",
            Url = new Uri("https://www.linkedin.com/in/mikerozendo/")
        }
    });
});

builder.Services.RegisterServices();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,

             ValidIssuer = jwtConfiguration.Issuer,
             ValidAudience = jwtConfiguration.Audience,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key))
         };
         options.Events = new JwtBearerEvents
         {
             OnChallenge = async context =>
             {
                 context.HandleResponse();
                 context.Response.StatusCode = 401;
                 context.Response.Headers.Append("authentication", "failed");
                 await context.Response.WriteAsync($"Por favor se autentifique em api/Auth/");
             }
         };
     });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
