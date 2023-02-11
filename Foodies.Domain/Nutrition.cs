using System.ComponentModel.DataAnnotations;

namespace Foodies.Domain
{
    public class Nutrition
    {
        public Nutrition()
        {
            FoodNutritions = new List<FoodNutrition>();
        }
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ModifiedAt { get; set; }

        public ICollection<FoodNutrition> FoodNutritions { get; set; }
    }
}
