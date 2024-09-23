using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReceipeBlog.Model;
using ReceipeBlog.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ReceipeBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IReceipeRepository _receipeRepository;

        private readonly IIngredientRepository _ingredientRepository;

        private readonly IFoodReceipeIngredientRepository _foodReceipeIngredientRepository;

        public HomeController(IReceipeRepository receipeRepository, IIngredientRepository ingredientRepository, IFoodReceipeIngredientRepository foodReceipeIngredientRepository)
        {
            _receipeRepository = receipeRepository;
            _ingredientRepository = ingredientRepository;
            _foodReceipeIngredientRepository = foodReceipeIngredientRepository;
        }

        [HttpGet("{id}")]

        public IActionResult GetReceipe(int id)
        {


            GetFoodReceipeDto foodReceipe = _receipeRepository.GetReceipe(id);
            

            if (foodReceipe != null)
            {
                return Ok(foodReceipe);
            }

            else
            {
                return NotFound();
            }
        }

        [HttpGet]

        public IEnumerable<GetFoodReceipeDto> GetAllReceipe()
        {
            return _receipeRepository.GetAllReceipes();
        }

        [HttpPost]

        public IActionResult AddNewReceipe([FromBody] FoodReceipeDto foodReceipeDto)
        {
            var foodReceipe = new FoodReceipe
            {
                ReceipeName = foodReceipeDto.ReceipeName,
                ReceipeDescription = foodReceipeDto.ReceipeDescription
            };

            _receipeRepository.AddReceipe(foodReceipe);

            foreach (var ingredientId in foodReceipeDto.IngredientIds)
            {
                // Check if the ingredient exists
                var ingredients = _ingredientRepository.GetIngredient(ingredientId);

                if (ingredients == null)
                {
                    return BadRequest($"Ingredient with ID {ingredientId} does not exist.");
                }
                var foodReceipeIngredient = new FoodReceipeIngredient
                {
                    FoodReceipeId = foodReceipe.Id,
                    IngredientId = ingredientId
                };

                _foodReceipeIngredientRepository.AddFoodReceipeIngredient(foodReceipeIngredient);






            }


            return Ok();




        }

        [HttpPut("{id}")]

        public IActionResult UpdateReceipe(int id ,[FromBody] FoodReceipeDto foodReceipeDto)
        {
            var ExistingReceipe = _receipeRepository.GetReceipe(id);

           if(ExistingReceipe == null)
            {
                return BadRequest("Id not available");
            }
           


            //FoodReceipe foodReceipe = 

            // ExistingReceipe.Ingredients.Clear();

           var UpdatefoodReceipe = _receipeRepository.UpdateReceipe(id,foodReceipeDto);
            var IngredientsToRemove = UpdatefoodReceipe.FoodReceipeIngredients.Where(r => !foodReceipeDto.IngredientIds.Contains(r.IngredientId)).ToList();
            foreach(var Ingridient in IngredientsToRemove)
            {
                _foodReceipeIngredientRepository.DeleteFoodReceipeIngredient(Ingridient);
            }

            return Ok(_receipeRepository.GetReceipe(id));












        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReceipe(int id)
        {
            var ExistingReceipe = _receipeRepository.GetReceipe(id);

            if(ExistingReceipe != null)
            {
                _receipeRepository.DeleteReceipe(id);

                return Ok(_receipeRepository.GetAllReceipes());
            }

            else
            {
                return BadRequest("Id not avaialbe");
            }
        }
    }
}
