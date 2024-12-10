namespace HearthStoneApp.WorkerService.Services.Interfaces
{
    public interface IHearthStoneApiService
    {
        Task<string> GetCardsAsync();
    }
}
