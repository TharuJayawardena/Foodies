using Foodies.Domain;

namespace Foodies.UI.Models
{
    public class NutritionViewModel
    {
        public NutritionViewModel()
        {
            Nutritions = new List<Nutrition>();
        }
        public IEnumerable<Nutrition> Nutritions { get; set; }


        // Post
        public string? Name { get; set; }
        public string? Description { get; set; }
        
    }
}
