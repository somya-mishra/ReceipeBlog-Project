namespace ReceipeBlog.DTOs
{
    public class FoodReceipeDto
    {
        public string ReceipeName { get; set; }
        public string ReceipeDescription { get; set; }
        public List<int> IngredientIds { get; set; }
    }
}
