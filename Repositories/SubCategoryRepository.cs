using NationBenefits.Context;
using NationBenefits.Interfaces;
using NationBenefits.Models;

namespace NationBenefits.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public SubCategory AddSubCategory(SubCategory subCategory)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubCategory(string id)
        {
            throw new NotImplementedException();
        }

        public List<SubCategory> GetAllSubCategories()
        {
            var result = _context.SubCategories.ToList();
            return result;
        }

        public List<SubCategory> GetSubCategoriesByCategoryId(string categoryId)
        {
            throw new NotImplementedException();
        }

        public SubCategory GetSubCategoryById(string id)
        {
            throw new NotImplementedException();
        }

        public SubCategory UpdateSubCategory(SubCategory subCategory)
        {
            throw new NotImplementedException();
        }
    }
}
