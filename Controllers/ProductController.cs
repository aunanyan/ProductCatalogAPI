using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogAPI.Models;
using ProductCatalogAPI.Repositories;

namespace ProductCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("AddProduct")]
        public ActionResult AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
            return Ok();

         }

        [HttpGet("GetAllProduct")]
        public ActionResult<IEnumerable<Product>> GetAllProduct()
        {
            var all = _productRepository.GetAll();
            return Ok(all);
        }

        [HttpGet("GetById")]
        public ActionResult GetById(int id)
        {
            var getid = _productRepository.GetById(id);
            return Ok(getid);
        }

        [HttpDelete("DeleteProduct")]
        public ActionResult DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
            return Ok();
        }

        [HttpPut("UpdateProduct")]
        public ActionResult UpdateProduct(Product product,int id)
        {
            var del = _productRepository.GetById(id);
            if (del == null)
                return NotFound();

            product.Id = id;
            _productRepository.UpdateProduct(product);
            return Ok();
        }
    }
}
