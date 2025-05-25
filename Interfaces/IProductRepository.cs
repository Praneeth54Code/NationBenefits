using NationBenefits.Models;

namespace NationBenefits.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        Product GetProductById(string id);

        List<SubCategory> GetAllSubCategories();
    }
}
