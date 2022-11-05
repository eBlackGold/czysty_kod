using CoalStore.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoalStore.Services.IServices;
using CoalStore.Shared.Models.Product;

namespace CoalStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Gets product supply for supplier
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns>list of products for supplier</returns>
        [HttpGet("get-suppliers-products/{userLogin}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ICollection<ProductSupplyModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProductSupply(string userLogin)
        {
            var result = await _productService.GetProductsForSupplier(userLogin);
            return Ok(result);
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns>list of all products</returns>
        [HttpGet("get-all-products")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ICollection<ProductSupplyModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllCurrentSupply();
            return Ok(result);
        }

        /// <summary>
        /// Adds product supply
        /// </summary>
        /// <remarks>Policy = Allow Anonymous</remarks>
        /// <returns></returns>
        [HttpPost("add-product")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ICollection<ProductSupplyModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetailsModel), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddProduct([FromBody] AddSupplyModel model)
        {
            await _productService.AddProduct(model);
            return Ok();
        }
    }
}
