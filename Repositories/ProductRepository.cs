using Microsoft.EntityFrameworkCore;
using NationBenefits.Context;
using NationBenefits.Interfaces;
using NationBenefits.Models;

namespace NationBenefits.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public ProductRepository(ApplicationDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger= logger;
        }

        public List<Product> GetAllProducts()
        {
            var result = _context.Products.ToList();
            return result;
        }

        public int InsertProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
               int i = _context.SaveChanges();
                return i;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return -1;
            }
        }

        public List<SubCategory> GetAllSubCategories()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(string id)
        {
            throw new NotImplementedException();
        }


        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<PaginatedProducts> GetPaginatedProductsAsync(int pageNumber, int pageSize, string? productCode)
        {

            //if (pageNumber <= 0 || pageSize <= 0)
            //{
            //    return BadRequest("Page number and page size must be greater than zero.");
            //}

            // Fetch the filtered and paginated products
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(productCode))
            {
                query = query.Where(p => p.ProductCode.Contains(productCode));
            }

            var totalProducts = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);

            var products = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return the paginated and filtered result with metadata
            PaginatedProducts response = new PaginatedProducts
            {
                TotalItems = totalProducts,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Products = products
            };

            return response;

        }

        public int UpdateProduct(Product product)
        {
            try
            {
                var prd = _context.Products.Find(product.Id);
                if(prd == null)
                {
                    return 0; // Product not found
                }

                _context.Products.Update(product);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product");
                return -1; // Indicate failure
            }
        }

        public int DeleteProduct(Guid id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return 0; // Product not found
                }
                _context.Products.Remove(product);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product");
                return -1; // Indicate failure
            }
        }

        public Product GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
