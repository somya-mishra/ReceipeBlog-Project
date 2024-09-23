namespace ReceipeBlog.Model
{
    public interface IIngredientRepository
    {
        Ingredients GetIngredient(int id);
        IEnumerable<Ingredients> GetAllIngredient();

        Ingredients AddIngredient(Ingredients ingredients);
        Ingredients UpdateIngredient(Ingredients ingredients);

        Ingredients DeleteIngredient(int id);
    }
}
