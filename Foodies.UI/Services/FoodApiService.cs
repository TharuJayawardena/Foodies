using Foodies.Domain;

namespace Foodies.UI.Services
{

    public class FoodApiService
    {
        private readonly HttpClient _httpClient;

        public FoodApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Food>> GetFoodsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Food>>("/api/Foods") ?? Enumerable.Empty<Food>();
        }
        public async Task<bool> CreateFoodAsync(Food food)
        {
            var response =  await _httpClient.PostAsJsonAsync<Food>("/api/Foods",food);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
            
        }
    }
}
