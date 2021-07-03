using Ecommerce.BusinessLogic;
using Ecommerce.BusinessLogic.Interfaces;
using Ecommerce.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ecommerce.API
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(
            ILogger<ProductController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost]
        [Authorize(Policy = Claims.CAN_CREATE_PRODUCT)]
        public async Task<IActionResult> Post(ProductToCreateDto product)
        {
            var createdProduct = await _productService.CreateAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }
        
        [HttpGet("{id}")]
        [Authorize(Policy = Claims.CAN_READ_PRODUCT)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productService.ReadAsync(id));
        }

        [HttpGet]
        [Authorize(Policy = Claims.CAN_READ_PRODUCT)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.ReadAsync());
        }

        [HttpPut]
        [Authorize(Policy = Claims.CAN_UPDATE_PRODUCT)]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto productDto)
        {
            return Ok(await _productService.UpdateAsync(productDto));
        }
    
        [HttpDelete]
        [Authorize(Policy = Claims.CAN_DELETE_PRODUCT)]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _productService.DeleteAsync(id);
            return Ok(id);
        }
    }
}
