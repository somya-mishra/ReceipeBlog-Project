namespace ReceipeBlog.DTOs
{
    public class GetFoodReceipeDto
    {
        
        
            public int Id { get; set; }
            public string ReceipeName { get; set; }
            public string ReceipeDescription { get; set; }
            public List<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();
        

        

    }
}
