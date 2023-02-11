using Newtonsoft.Json;

namespace Foodies.Inventory.API.Dto
{
    public class UpdateFoodDto
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
    }
}
