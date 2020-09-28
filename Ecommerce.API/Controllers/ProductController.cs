﻿using Ecommerce.Business.Dto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.API
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
        [AuthorizeRoles(Roles.Admin, Roles.Manager, Roles.Employee)]
        public IActionResult Post(ProductDto product)
        {
            return Ok(_productService.Create(product));
        }

        [HttpGet]
        [AuthorizeRoles(Roles.Admin, Roles.Manager, Roles.Employee)]
        public IActionResult Get(int id)
        {
            var product = _productService.Read(id);
            
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("All")]
        [AuthorizeRoles(Roles.Admin, Roles.Manager, Roles.Employee)]
        public IActionResult Get()
        {
            var product = _productService.Read();

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("Filter")]
        [AuthorizeRoles(Roles.Admin, Roles.Manager, Roles.Employee)]
        public IActionResult Get([FromQuery] ProductFilterDto productFilterDto)
        {
            var product = _productService.Read(productFilterDto);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPut]
        [AuthorizeRoles(Roles.Admin, Roles.Manager, Roles.Employee)]
        public IActionResult Update([FromBody] ProductDto productDto)
        {
            return Ok(_productService.Update(productDto));
        }
    
        [HttpDelete]
        [AuthorizeRoles(Roles.Admin, Roles.Manager, Roles.Employee)]
        public IActionResult Delete([FromQuery] int id)
        {
            _productService.Delete(id);
            return Ok(id);
        }
    }
}
