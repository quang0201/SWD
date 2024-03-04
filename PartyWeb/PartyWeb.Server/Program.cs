using BusinessObjects.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Reponsitories.Interface;
using Reponsitories.Repositories;
using Server.Interface;
using Services.Interface;
using Services.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//config repo

builder.Services.AddScoped<IUserService, UserService>();

//config service

builder.Services.AddScoped<IUserRepository, UserRepository>();

//config database

builder.Services.AddDbContext<SwdContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));




builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "API",
        Description = "Đang làm",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "quang",
            Email = "quang020102@gmail.com",
        },
    });
    // Thêm JWT Bearer Token vào Swagger
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "JWT Authorization header sử dụng scheme Bearer.",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Name = "Authorization",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddAuthentication(e =>
{
    e.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    e.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddCookie(x =>
{
    x.Cookie.SameSite = SameSiteMode.Strict;
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    x.Cookie.IsEssential = true;
})
  .AddJwtBearer(e =>
  {
      e.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = builder.Configuration.GetSection("JwtSettings:Issuer").Value!,
          ValidAudience = builder.Configuration.GetSection("JwtSettings:Audience").Value!,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtSettings:SecretKey").Value!))
      };
      e.SaveToken = true;
      e.RequireHttpsMetadata = true;
      e.Events = new JwtBearerEvents();
      e.Events.OnMessageReceived = context =>
      {

          if (context.Request.Cookies.ContainsKey("JwtTokenCookie"))
          {
              context.Token = context.Request.Cookies["JwtTokenCookie"];
          }

          return Task.CompletedTask;
      };
  });
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();