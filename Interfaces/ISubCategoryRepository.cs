using NationBenefits.Models;

namespace NationBenefits.Interfaces
{
    public interface ISubCategoryRepository
    {
        List<SubCategory> GetAllSubCategories();

        SubCategory GetSubCategoryById(string id);

        List<SubCategory> GetSubCategoriesByCategoryId(string categoryId);

        SubCategory AddSubCategory(SubCategory subCategory);

        SubCategory UpdateSubCategory(SubCategory subCategory);

        void DeleteSubCategory(string id);
    }
}
