using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.API
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IServiceDto<ProductDto> _productService;

        public ProductController(ILogger<ProductController> logger, IServiceDto<ProductDto> productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Post(ProductDto product)
        {
            return Ok(_productService.Create(product).Id);
        }
    }
}
