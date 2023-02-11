using System.ComponentModel.DataAnnotations;

namespace Foodies.Domain
{
    public class Food
    {
        public Food()
        {
            FoodNutritions = new List<FoodNutrition>();
        }
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ModifiedAt { get; set; }

        public ICollection<FoodNutrition> FoodNutritions { get; set; }
    }
}
