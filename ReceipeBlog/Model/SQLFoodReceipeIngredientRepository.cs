namespace ReceipeBlog.Model
{
    public class SQLFoodReceipeIngredientRepository : IFoodReceipeIngredientRepository
    {
        private readonly AppDbContext _appDbContext;

        public SQLFoodReceipeIngredientRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public FoodReceipeIngredient AddFoodReceipeIngredient(FoodReceipeIngredient foodReceipeIngredient)
        {
            _appDbContext.FoodReceipeIngredients.Add(foodReceipeIngredient);
            _appDbContext.SaveChanges();

            return foodReceipeIngredient;
        }

        public IEnumerable<FoodReceipeIngredient> GetAllFoodReceipeIngredient()
        {
            return _appDbContext.FoodReceipeIngredients;
        }

       public FoodReceipeIngredient DeleteFoodReceipeIngredient(FoodReceipeIngredient foodReceipeIngredient)
        {

            _appDbContext.FoodReceipeIngredients.Remove(foodReceipeIngredient);
            _appDbContext.SaveChanges();
            return foodReceipeIngredient;
        }
    }
}
