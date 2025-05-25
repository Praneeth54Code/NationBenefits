using NationBenefits.Context;
using NationBenefits.Interfaces;
using NationBenefits.Models;

namespace NationBenefits.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            var result = _context.Products.ToList();
            return result;
        }

        public List<SubCategory> GetAllSubCategories()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
