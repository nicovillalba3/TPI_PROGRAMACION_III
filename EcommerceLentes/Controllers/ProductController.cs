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

        // Constructor actualizado para inyectar IProductService
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
                return NotFound("Product not found.");
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
                return Ok(new { message = "Product Added" });
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
                return Ok(new { message = "Product Updated" });
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
                return Ok("Product deleted successfully.");
            }
            else
            {
                return NotFound("Product not found.");
            }
        }
    }
}
