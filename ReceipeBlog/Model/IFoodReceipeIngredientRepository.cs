namespace ReceipeBlog.Model
{
    public interface IFoodReceipeIngredientRepository
    {
        IEnumerable<FoodReceipeIngredient> GetAllFoodReceipeIngredient();

        FoodReceipeIngredient AddFoodReceipeIngredient(FoodReceipeIngredient foodReceipeIngredient);

        FoodReceipeIngredient DeleteFoodReceipeIngredient(FoodReceipeIngredient foodReceipeIngredient);
    }
}
