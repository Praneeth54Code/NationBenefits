using NationBenefits.Models;

namespace NationBenefits.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        int InsertProduct(Product product);

        int UpdateProduct(Product product);

        int DeleteProduct(Guid id);

        Product GetProductById(Guid id);

        List<SubCategory> GetAllSubCategories();

         Task<int> GetTotalCountAsync();

        Task<PaginatedProducts> GetPaginatedProductsAsync(int pageNumber, int pageSize,string? productCode);
    }
}
