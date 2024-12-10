using dotenv.net;
using Hangfire;
using HearthStoneApp.Aplication.Profiles;
using HearthStoneApp.Aplication.Repository;
using HearthStoneApp.Aplication.Repository.Interfaces;
using HearthStoneApp.Aplication.Services;
using HearthStoneApp.Aplication.Services.Interfaces;
using HearthStoneApp.Infrastructure.Data;
using HearthStoneApp.WorkerService;
using HearthStoneApp.WorkerService.HostedServices;
using HearthStoneApp.WorkerService.Interfaces;
using HearthStoneApp.WorkerService.Services;
using HearthStoneApp.WorkerService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                DotEnv.Load();
                var envConnectionString = hostContext.Configuration.GetConnectionString("Connection");
                var connectionString = Environment.GetEnvironmentVariable(envConnectionString);

                services.AddHangfire(configuration =>
                    configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                        .UseSimpleAssemblyNameTypeSerializer()
                        .UseRecommendedSerializerSettings()
                        .UseSqlServerStorage(connectionString));

                services.AddHangfireServer();

                services.AddAutoMapper(typeof(CardProfile).Assembly);

                services.AddHttpClient<IHearthStoneApiService, HearthStoneApiService>();

                //services
                services.AddScoped<ICardService, CardService>();
                services.AddScoped<IRarityService, RarityService>();

                //repositories
                services.AddScoped<ICardRepository, CardRepository>();
                services.AddScoped<IRarityRepository, RarityRepository>();

                //crons
                services.AddScoped<ICardSyncJob, CardSyncJob>();

                services.AddDbContext<HearthStoneDbContext>(options =>
                    options.UseSqlServer(connectionString));


                services.AddHostedService<CardSyncJobHostedService>();
            });
}