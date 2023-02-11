namespace Foodies.Domain
{
    public class FoodNutrition
    {
        public int Id { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; }

        public int NutritionId { get; set; }
        public Nutrition Nutrition { get; set; }


    }
}
