using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReceipeBlog.DTOs;
using ReceipeBlog.Model;

namespace ReceipeBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {

        //private readonly IReceipeRepository _receipeRepository;

        private readonly IIngredientRepository _ingredientRepository;

       private readonly IFoodReceipeIngredientRepository _foodReceipeIngredientRepository;
        public IngredientController(IIngredientRepository ingredientRepository, IFoodReceipeIngredientRepository foodReceipeIngredientRepository)
        {
            _ingredientRepository = ingredientRepository;
            _foodReceipeIngredientRepository = foodReceipeIngredientRepository; 
        }

        [HttpGet("id")]
        public IActionResult GetIngredient(int id)
        {
            
           return Ok( _ingredientRepository.GetIngredient(id));

        }


        [HttpGet]
        public IActionResult GetAllIngredient()
        {

            return Ok(_ingredientRepository.GetAllIngredient());

        }



        [HttpPost]
        public IActionResult AddlIngredient( [FromBody]IngredientDto ingredients)
        {
            Ingredients ingredients1 = new Ingredients()
            {
                IngredientName=ingredients.IngredientName,
                Quantity=ingredients.Quantity
            };

            return Ok(_ingredientRepository.AddIngredient(ingredients1));

        }

        [HttpPut("id")]

        public IActionResult UpdatelIngredient(int id ,[FromBody] IngredientDto ingredients)
        {

          var result =   _ingredientRepository.GetIngredient(id);
            if(result == null)
            {
                return BadRequest("Id oesnot exist");

            }

            else
            {
               result.IngredientName = ingredients.IngredientName;  
                result.Quantity = ingredients.Quantity; 
                return Ok( _ingredientRepository.UpdateIngredient(result));
            }


        }

        [HttpDelete]

        public IActionResult DeleteIngredient(int id)
        {
           var ingredient =  _ingredientRepository.GetIngredient(id);

            if(ingredient == null)
            {
                return BadRequest("id doesnot exist");
            }

            else
            {
              return Ok(  _ingredientRepository.DeleteIngredient(id));
            }
        }



    }
}
