using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add/{orderId}")]
        public IActionResult AddProduct(int orderId, [FromBody] Product product)
        {
            _cartService.AddProductToCart(orderId, product);
            return Ok();
        }

        [HttpPost("remove/{orderId}")]
        public IActionResult RemoveProduct(int orderId, [FromBody] Product product)
        {
            _cartService.RemoveProductFromCart(orderId, product);
            return Ok();
        }

        [HttpDelete("{orderId}")]
        public IActionResult DeleteCart(int orderId)
        {
            _cartService.DeleteCart(orderId);
            return Ok();
        }

        [HttpPut("update/{orderId}")]
        public IActionResult UpdateProductStock(int orderId, [FromBody] UpdateProductDto updateProductDto)
        {
            _cartService.UpdateProductStock(orderId, updateProductDto);
            return Ok();
        }

        [HttpGet("totalprice/{orderId}")]
        public IActionResult GetTotalPrice(int orderId)
        {
            return Ok(_cartService.GetTotalPrice(orderId));
        }

        [HttpGet("totalproducts/{orderId}")]
        public IActionResult GetTotalProducts(int orderId)
        {
            return Ok(_cartService.GetTotalProducts(orderId));
        }
    }
}

