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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public ProductController(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var currentUser = await _userService.GetCurrentUserAsync();
            if (currentUser == null || currentUser.Role != UserRole.Admin)
            {
                return Unauthorized(new { message = "Only admins can create products." });
            }
            var result = await _productService.CreateProductAsync(product);
            if (result)
            {
                return Ok(new { message = "Product created successfully!" });
            }
            return BadRequest(new { message = "Product already exists." });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var currentUser = await _userService.GetCurrentUserAsync();
            if (currentUser == null || currentUser.Role != UserRole.Admin)
            {
                return Unauthorized(new { message = "Only admins can create products." });
            }
            var result = await _productService.UpdateProductAsync(product);
            if (result)
            {
                return Ok(new { message = "Product updated successfully!" });
            }
            return BadRequest(new { message = "Product does not exist." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var currentUser = await _userService.GetCurrentUserAsync();
            
            if (currentUser == null || currentUser.Role != UserRole.Admin)
            {
                return Unauthorized(new { message = "Only admins can delete products." });
            } 

            var result = await _productService.DeleteProductAsync(id);
            if (result)
            {
                return Ok(new { message = "Product deleted successfully!" });
            }
            return BadRequest(new { message = "Product does not exist." });
        }
    }
}
