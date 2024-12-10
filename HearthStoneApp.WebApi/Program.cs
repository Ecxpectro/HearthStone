using dotenv.net;
using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Aplication.Repository;
using Microsoft.EntityFrameworkCore;
using HearthStoneApp.Aplication.Services.Interfaces;
using HearthStoneApp.Aplication.Services;
using HearthStoneApp.Infrastructure.Data;
using HearthStoneApp.Aplication.Profiles;

var builder = WebApplication.CreateBuilder(args);
DotEnv.Load();

var envorimentConnectionString = builder.Configuration.GetConnectionString("Connection");
var connectionString = Environment.GetEnvironmentVariable(envorimentConnectionString);

builder.Services.AddDbContext<HearthStoneDbContext>(opt =>
{
    opt.UseSqlServer(connectionString,
                     sqlServerOptionsAction: sqlOptions =>
                     {
                         sqlOptions.EnableRetryOnFailure();
                     });
});
builder.Services.AddAutoMapper(typeof(CardProfile).Assembly);

builder.Services.AddScoped<ICardRepository, CardRepository>();

builder.Services.AddScoped<ICardService, CardService>();

// Add services to the container.

builder.Services.AddControllers();
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
