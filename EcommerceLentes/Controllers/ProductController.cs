using Application.Dtos;
using Application.Services;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _service.Get(id);
            if (product == null)
            {
                return NotFound("Producto no encontrado.");
            }
            return Ok(product);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductForAddRequest body)
        {
            try
            {
                _service.AddProduct(body);
                return Ok(new { message = "Producto agregado!" });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductForUpdateRequest body)
        {
            try
            {
                _service.UpdateProduct(body);
                return Ok(new { message = "Producto actualizado!" });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, int userId)
        {
            var result = _service.DeleteProduct(id, userId);
            if (result)
            {
                return Ok("Producto borrado con éxito!");
            }
            else
            {
                return NotFound("Producto no encontrado.");
            }
        }
    }
}
