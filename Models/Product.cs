namespace NationBenefits.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid SubCategory_Id { get; set; }
        public string SKI { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

        public string ProductCode { get; set; }
    }
}
