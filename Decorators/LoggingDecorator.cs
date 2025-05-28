using NationBenefits.Interfaces;
using NationBenefits.Models;
using NationBenefits.Repositories;

namespace NationBenefits.Decorators
{
    public class LoggingDecorator : IProductRepository
    {

        private readonly IProductRepository _productrepository;
        private readonly ILogger<LoggingDecorator> _logger;

        public LoggingDecorator(IProductRepository productRepository, ILogger<LoggingDecorator> logger)
        {
            _productrepository= productRepository;
            _logger= logger;
        }

        

        public List<Product> GetAllProducts()
        {
            var products = _productrepository.GetAllProducts();
            _logger.LogInformation("GetAllProducts Executed Successfully");
            return products;
        }

        public List<SubCategory> GetAllSubCategories()
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedProducts> GetPaginatedProductsAsync(int pageNumber, int pageSize, string? productCode)
        {
            _logger.LogInformation("Getting Paginated Products");
            var result = _productrepository.GetPaginatedProductsAsync(pageNumber, pageSize, productCode);
            _logger.LogInformation($"Retrieved {result.Result.Products.Count} products for page {pageNumber} with page size {pageSize}");
            return result;
        }

        public Product GetProductById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCountAsync()
        {
            throw new NotImplementedException();
        }

        public int InsertProduct(Product product)
        {
            int i = _productrepository.InsertProduct(product);
            _logger.LogInformation($"Inserted Product {i}");
            return i;
        }

        public int UpdateProduct(Product product)
        {
            int i = _productrepository.UpdateProduct(product);
            _logger.LogInformation($"Updated Product {i}");
            return i;
        }


        public int DeleteProduct(Guid id)
        {
            int i = _productrepository.DeleteProduct(id);
            if (i > 0)
            {
                _logger.LogInformation($"Deleted Product with ID: {id}");
            }
            else
            {
                _logger.LogWarning($"Failed to delete Product with ID: {id}");
            }
            return i;
        }

        public Product GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
