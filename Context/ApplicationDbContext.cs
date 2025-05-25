using Microsoft.EntityFrameworkCore;
using NationBenefits.Models;

namespace NationBenefits.Context

{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
    }
}
