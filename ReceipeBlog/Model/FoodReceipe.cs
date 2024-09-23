namespace ReceipeBlog.Model
{
    public class FoodReceipe
    {
        public int Id { get; set; }
        public string ReceipeName { get; set; }

        


        public string ReceipeDescription { get; set; }

        //public List<int> IngredientIds { get; set; } = new List<int>();

        public ICollection<FoodReceipeIngredient> FoodReceipeIngredients { get; set; } = new List<FoodReceipeIngredient>();
    }
}
