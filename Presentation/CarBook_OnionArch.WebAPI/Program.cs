using CarBook_OnionArch.Application.Extensions;
using CarBook_OnionArch.Application.Validators.ReviewValidators;
using CarBook_OnionArch.Persistence.Extensions;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Application layer services extension
builder.Services.AddApplicationServices();

//Persistence layer services extension
builder.Services.AddPersistenceServices(builder.Configuration);

//FluentAPI Registration
builder.Services.AddValidatorsFromAssemblyContaining<CreateReviewValidator>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
