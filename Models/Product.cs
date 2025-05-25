namespace NationBenefits.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string SubCategoryId { get; set; }
        public string SKI { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
