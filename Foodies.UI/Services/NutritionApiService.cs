using Foodies.Domain;

namespace Foodies.UI.Services
{
    public class NutritionApiService
    {
       private readonly HttpClient _httpClient;

       public NutritionApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Nutrition>> GetNutritionsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Nutrition>>("/api/Nutritions") ?? Enumerable.Empty<Nutrition>();
        }
        public async Task<bool> CreateNutritionAsync(Nutrition nutrition)
        {
            var response = await _httpClient.PostAsJsonAsync<Nutrition>("/api/Nutritions", nutrition);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }
    }
}
