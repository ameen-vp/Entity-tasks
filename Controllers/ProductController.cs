using EntityInsoteredprocedure_allcrud.Models;
using EntityInsoteredprocedure_allcrud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityInsoteredprocedure_allcrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Iproductservice _productService;

        public ProductController(Iproductservice productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Productclass>>> Get()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]Productclass product)
        {
            await _productService.CreateProductAsync(product);
            return Ok("Product Created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromForm]int id, Productclass product)
        {
            await _productService.UpdateProductAsync(id, product);
            return Ok("Product Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Product Deleted");
        }
    }
}
