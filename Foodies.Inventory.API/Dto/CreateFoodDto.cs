namespace Foodies.Inventory.API.Dto
{
    public class CreateFoodDto
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
    }
}
