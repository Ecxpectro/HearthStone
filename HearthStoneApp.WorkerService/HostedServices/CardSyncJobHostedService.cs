using Hangfire;
using HearthStoneApp.WorkerService.Interfaces;

namespace HearthStoneApp.WorkerService.HostedServices
{
    public class CardSyncJobHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CardSyncJobHostedService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scopeServiceFactory = _serviceScopeFactory.CreateScope())
            {
                var jobService = scopeServiceFactory.ServiceProvider.GetRequiredService<ICardSyncJob>();

                RecurringJob.AddOrUpdate(() => jobService.SyncCardsAsync(), Cron.Minutely);
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
