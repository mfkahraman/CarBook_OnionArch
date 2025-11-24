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

// Add services to the container.

builder.Services.AddControllers();

//Application layer services extension
builder.Services.AddApplicationServices();

//Persistence layer services extension
builder.Services.AddPersistenceServices(builder.Configuration);

//FluentAPI Registration
builder.Services.AddValidatorsFromAssemblyContaining<CreateReviewValidator>();

// JwtSecurityTokenHandler registration
builder.Services.AddSingleton<JwtSecurityTokenHandler>();

//JWT Bearer Authentication Configuration
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

// TokenOptions configuration binding
builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection(nameof(TokenOptions)));

// Authorization policy registration
builder.Services.AddAuthorizationBuilder()
    .AddDefaultPolicy("Default", policy =>
    {
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
    });

//Identity Registration
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

//CORS Configuration
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});

//SignalR Configuration
builder.Services.AddSignalR();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS Middleware registration
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//SignalR Hub mapping
app.MapHub<MessageHub>("/messagehub");

app.Run();
