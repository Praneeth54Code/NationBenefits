using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationBenefits.Interfaces;
using NationBenefits.Models;
using NationBenefits.Repositories;

namespace NationBenefits.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving products: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsWithPagination(int pageNumber=1, int pageSize=10, string? productCode = null)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }
            var products = await _productRepository.GetPaginatedProductsAsync(pageNumber, pageSize,productCode);
            return Ok(products);
        }


  

        [HttpPost]
        public IActionResult InsertProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }

            try
            {
                var result = _productRepository.InsertProduct(product);
                if (result > 0)
                {
                    return Ok("Product inserted successfully");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting product");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error inserting product: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {

            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }

            try
            {
                var result = _productRepository.UpdateProduct(product);
                if (result > 0)
                {
                    return Ok("Product updated successfully");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating product");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating product: {ex.Message}");
            }
        
        }

        [HttpDelete]
        public IActionResult DeleteProduct(Guid Id) 
        {
            if (Id == null)
            {
                return BadRequest("Product ID cannot be null or empty");
            }

            try
            {
                var result = _productRepository.DeleteProduct(Id);
                if (result > 0)
                {
                    return Ok("Product deleted successfully");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting product");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting product: {ex.Message}");
            }
        }



    }
}
