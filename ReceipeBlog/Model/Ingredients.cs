namespace ReceipeBlog.Model
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }

        public int Quantity { get; set; }

        public ICollection<FoodReceipeIngredient> FoodReceipeIngredients { get; set; } = new List<FoodReceipeIngredient>();

    }
}
