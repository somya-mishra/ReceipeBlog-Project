using ReceipeBlog.DTOs;
using System.Collections.Generic;
namespace ReceipeBlog.Model
{
    public interface IReceipeRepository

    {
        GetFoodReceipeDto GetReceipe(int id);
        IEnumerable<GetFoodReceipeDto> GetAllReceipes();

        FoodReceipe AddReceipe(FoodReceipe foodReceipe);
        FoodReceipe UpdateReceipe(int id,FoodReceipeDto foodReceipe);

        FoodReceipe DeleteReceipe(int id);
    }
}
