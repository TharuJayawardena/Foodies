using Foodies.Domain;
using System.ComponentModel.DataAnnotations;

namespace Foodies.UI.Models;

public class FoodViewModel
{
    public FoodViewModel()
    {
        Foods = new List<Food>();
    }
    public IEnumerable<Food> Foods { get; set; }


    // Post
    [Required]
    public string? Name { get; set; }
    public string? Image { get; set; }
    public decimal? Price { get; set; }
}
