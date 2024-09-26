using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReceipeBlog.Model;

namespace ReceipeBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        //private readonly IFoodReceipeIngredientRepository _foodReceipeIngredientRepository;
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]

        public IActionResult GetAllRoles()
        {
            return Ok(_roleRepository.GetAllRole());

        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
           var  result = _roleRepository.GetRoleById(id);

            if(result == null)
            {
                return BadRequest("Id cannot be found");
            }



            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddRoles(Role role)
        {
          return Ok(  _roleRepository.AddRole(role));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoles(int id, [FromBody] Role role)
        {
            var result = _roleRepository.GetRoleById(id);

            if (result == null)
            {
                return BadRequest("Id not found");
            }

            else
            {
               result.Name = role.Name;
             return Ok(  _roleRepository.UpdateRole(result));


            }


        }
        [HttpDelete]
        public IActionResult DeleteRoleById(int id)
        {
            var result = _roleRepository.GetRoleById(id);

            if (result == null)
            {
                return BadRequest("Id not found");
            }
            else
            {
                return Ok( _roleRepository.DeleteRole(id));
            }

        }
    }
}
