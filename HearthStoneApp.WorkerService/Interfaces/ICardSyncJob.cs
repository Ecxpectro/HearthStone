namespace HearthStoneApp.WorkerService.Interfaces
{
    public interface ICardSyncJob
    {
        Task SyncCardsAsync();
    }
}
