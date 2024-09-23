namespace ReceipeBlog.Model
{
    public class FoodReceipeIngredient
    {
        public int FoodReceipeId { get; set; }
        public FoodReceipe FoodReceipe { get; set; }

        public int IngredientId { get; set; }

        public Ingredients Ingredients { get; set; }
    }
}
