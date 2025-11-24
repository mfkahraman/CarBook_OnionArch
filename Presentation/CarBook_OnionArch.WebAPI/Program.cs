using CarBook_OnionArch.Application.Extensions;
using CarBook_OnionArch.Application.Options;
using CarBook_OnionArch.Application.Validators.ReviewValidators;
using CarBook_OnionArch.Domain.Entities;
using CarBook_OnionArch.Persistence.Context;
using CarBook_OnionArch.Persistence.Extensions;
using CarBook_OnionArch.WebAPI.Hubs;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// CORS: Tekrarlanan AddSignalR kaldırıldı; doğru policy adıyla tanımla
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsForSignalR", policy =>
    {
        policy.WithOrigins(
            "https://localhost:7290",  // WebUI HTTPS portu
            "http://localhost:7290")   // Eğer HTTP kullanırsan ekle
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// SignalR
builder.Services.AddSignalR();

// HttpClient
builder.Services.AddHttpClient();

// MVC Controllers
builder.Services.AddControllers();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining<CreateReviewValidator>();
builder.Services.AddSingleton<JwtSecurityTokenHandler>();

builder.Services.AddAuthentication(cfg =>
{
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    var jwtTokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>()
        ?? throw new InvalidOperationException("TokenOptions configuration is missing or invalid.");

    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidIssuer = jwtTokenOptions.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtTokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenOptions.Key ?? throw new InvalidOperationException("TokenOptions.Key is missing."))),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        NameClaimType = ClaimTypes.Name,
    };
});

builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection(nameof(TokenOptions)));

builder.Services.AddAuthorizationBuilder()
    .AddDefaultPolicy("Default", policy =>
    {
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
    });

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// ÖNEMLİ: UseRouting sonrası, UseAuthentication / UseAuthorization öncesi CORS
app.UseCors("CorsForSignalR");

app.UseAuthentication();
app.UseAuthorization();

// Hub endpoint (UI tarafı https://localhost:7290 üzerinden çağıracak)
app.MapHub<MessageHub>("/messageHub");

app.MapControllers();

app.Run();