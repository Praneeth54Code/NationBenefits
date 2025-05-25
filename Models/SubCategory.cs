namespace NationBenefits.Models
{
    public class SubCategory
    {
        public string SubCategoryId { get; set; }

        public string code { get; set; }
        public string description { get; set; }
        public string category_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
