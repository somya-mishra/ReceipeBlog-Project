namespace ReceipeBlog.Model
{
    public class SQLIngredientRepository : IIngredientRepository
    {
        private readonly AppDbContext _appDbContext;

        public SQLIngredientRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Ingredients AddIngredient(Ingredients ingredients)
        {
            _appDbContext.Ingredients.Add(ingredients);
            _appDbContext.SaveChanges();
            return ingredients;
            
        }

        public Ingredients DeleteIngredient(int id)
        {
            Ingredients ingredients = _appDbContext.Ingredients.Find(id);
            if(ingredients != null)
            {
              var result =   _appDbContext.FoodReceipeIngredients.Where(x => x.IngredientId == id).ToList();
                _appDbContext.FoodReceipeIngredients.RemoveRange(result);
                _appDbContext.Ingredients.Remove(ingredients);
                _appDbContext.SaveChanges();
            }

            return ingredients;
        }

        public IEnumerable<Ingredients> GetAllIngredient()
        {
            return _appDbContext.Ingredients;
        }

        public Ingredients GetIngredient(int id)
        {
            Ingredients ingredients = _appDbContext.Ingredients.SingleOrDefault(x => x.Id == id);
            return ingredients;

        }

        public Ingredients UpdateIngredient(Ingredients ingredients)
        {
            var ingredientsToUpdate = _appDbContext.Ingredients.Attach(ingredients);

            ingredientsToUpdate.State=Microsoft.EntityFrameworkCore.EntityState.Modified;

            _appDbContext.SaveChanges();

            return ingredients;
        }
    }
}
