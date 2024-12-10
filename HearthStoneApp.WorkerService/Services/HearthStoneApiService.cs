using dotenv.net;
using HearthStoneApp.WorkerService.Services.Interfaces;

namespace HearthStoneApp.WorkerService.Services
{
    public class HearthStoneApiService : IHearthStoneApiService
    {
        private readonly HttpClient _httpClient;

        public HearthStoneApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            DotEnv.Load();
        }

        public async Task<string> GetCardsAsync()
        {
            var key = Environment.GetEnvironmentVariable("RapidApiaKey");
            var url = "https://omgvamp-hearthstone-v1.p.rapidapi.com/cards/classes/Mage";
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", key);

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                return null!;
            }
        }
    }
}
