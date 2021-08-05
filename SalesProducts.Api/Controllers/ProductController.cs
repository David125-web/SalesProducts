using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesProducts.Api.Responses;
using SalesProducts.Core.DTOs;
using SalesProducts.Core.Entities;
using SalesProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SalesProducts.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        /// <summary>
        /// Return all post generators
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetProducts))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDTo>>))]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<PostDTo>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetProducts()
        {
            var products = _productService.GetProducts();
            var productsDtos = _mapper.Map<IEnumerable<ProductDTo>>(products);
            var response = new ApiResponse<IEnumerable<ProductDTo>>(productsDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            var productDto = _mapper.Map<ProductDTo>(product);
            var response = new ApiResponse<ProductDTo>(productDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductDTo productDTo)
        {
            var product = _mapper.Map<Product>(productDTo);
            await _productService.InsertProduct(product);
            var productDto = _mapper.Map<ProductDTo>(product);

            var response = new ApiResponse<ProductDTo>(productDto);

            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, ProductDTo productDTo)
        {
            var product = _mapper.Map<Product>(productDTo);
            product.Id = id;
            var result = await _productService.UpdateProduct(product);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProduct(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
