using Application.Dtos;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
     {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }


        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return Ok(_service.Get(name));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserForAddRequest body)
        {
            return Ok(_service.AddUser(body));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool isDeleted = _service.DeleteUser(id);
            if (isDeleted)
            {
                return Ok(new { message = "Usuario Eliminado" });
            }
            else
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserForUpdateRequest body)
        {
            _service.UpdateUser(body);
            return Ok(new { message = "Usuario Actualizado" });
        }

    }
}
