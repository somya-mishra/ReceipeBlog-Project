using Microsoft.EntityFrameworkCore;
using ReceipeBlog.DTOs;

namespace ReceipeBlog.Model
{
    public class SQLReceipeRepository:IReceipeRepository
    {
        private readonly AppDbContext _appDbContext;

        public SQLReceipeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public GetFoodReceipeDto GetReceipe(int id)
        {
          FoodReceipe foodReceipe = _appDbContext.FoodReceipes.Include(r => r.FoodReceipeIngredients).
                ThenInclude(r=> r.Ingredients).
                SingleOrDefault(x => x.Id==id);

            var GetFoodReceipeDto = new GetFoodReceipeDto
            {
                Id = foodReceipe.Id,
                ReceipeName = foodReceipe.ReceipeName,
                ReceipeDescription = foodReceipe.ReceipeDescription,
                Ingredients = foodReceipe.FoodReceipeIngredients.Select(fri => new IngredientDto
                {
                   // Id = fri.Ingredients.Id,
                    IngredientName = fri.Ingredients.IngredientName,
                    Quantity = fri.Ingredients.Quantity
                }).ToList()
            };






            return GetFoodReceipeDto;

        }

       public IEnumerable<GetFoodReceipeDto> GetAllReceipes()
        {
            var foodReceipes =  _appDbContext.FoodReceipes.Include(x => x.FoodReceipeIngredients).ThenInclude(x=>x.Ingredients).ToList();

            

           
            
                var getFoodReceipeDto = foodReceipes.Select(x => new GetFoodReceipeDto
                {
                    Id = x.Id,
                    ReceipeName = x.ReceipeName,
                    ReceipeDescription = x.ReceipeDescription,
                    Ingredients = x.FoodReceipeIngredients.Select(y => new IngredientDto
                    {
                        IngredientName = y.Ingredients.IngredientName,
                        Quantity = y.Ingredients.Quantity
                    }).ToList()


                });

               



            

            return getFoodReceipeDto;
        }

        public FoodReceipe AddReceipe(FoodReceipe foodReceipe)
        {
            _appDbContext.FoodReceipes.Add(foodReceipe);
            _appDbContext.SaveChanges();
            return foodReceipe; 
        }

        public FoodReceipe UpdateReceipe(int id,FoodReceipeDto foodReceipe)

        {

            FoodReceipe FoodReceipe = _appDbContext.FoodReceipes.Include(r => r.FoodReceipeIngredients).
                ThenInclude(r => r.Ingredients).
                SingleOrDefault(x => x.Id == id);

            FoodReceipe.ReceipeName = foodReceipe.ReceipeName;
            FoodReceipe.ReceipeDescription = foodReceipe.ReceipeDescription;
          // var IngredientName= foodReceipe.Ingredients.Select(x=>x.IngredientName).ToList();
            foreach(int ingedient in foodReceipe.IngredientIds)
            {
               int ingridientId = _appDbContext.Ingredients.Where(x=>x.Id==ingedient). Select(x=>x.Id).FirstOrDefault();
                if (ingridientId != 0)
                {


                    var result = _appDbContext.FoodReceipeIngredients.Where(x => x.FoodReceipeId == id && x.IngredientId == ingedient).FirstOrDefault();
                    if (result == null)
                    {
                        var foodReceipeIngredient = new FoodReceipeIngredient
                        {
                            FoodReceipeId = FoodReceipe.Id,
                            IngredientId = ingedient
                        };
                        _appDbContext.FoodReceipeIngredients.Add(foodReceipeIngredient);
                        _appDbContext.SaveChanges();

                    }
                }
            }
            


            var receipe =  _appDbContext.FoodReceipes.Attach(FoodReceipe);
            receipe.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.SaveChanges();
            return FoodReceipe;

        }

        public FoodReceipe DeleteReceipe(int id)
        {
            FoodReceipe foodReceipe = _appDbContext.FoodReceipes.Include(r => r.FoodReceipeIngredients).
                ThenInclude(r => r.Ingredients).
                SingleOrDefault(x => x.Id == id);

            var result = _appDbContext.FoodReceipeIngredients.Where(x => x.FoodReceipeId == foodReceipe.Id).ToList();

            if(result != null)
            {
                
                
                    _appDbContext.FoodReceipeIngredients.RemoveRange(result);
                    _appDbContext.SaveChanges();
                
            }

             if(foodReceipe != null)
            {
                _appDbContext.Remove(foodReceipe);
                _appDbContext.SaveChanges();
            }
            return foodReceipe;



        }
    }
}
