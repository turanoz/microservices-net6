using Catalog.Api.Dtos;
using Catalog.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.ControllerBases;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAllAsync();

            return CreateActionResultInstance(response);
        }

        //products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _productService.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto productCreateDto)
        {
            var response = await _productService.CreateAsync(productCreateDto);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            var response = await _productService.UpdateAsync(productUpdateDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _productService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}