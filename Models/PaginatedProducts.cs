﻿namespace NationBenefits.Models
{
    public class PaginatedProducts
    {
        public int TotalItems { get; set; }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<Product> Products { get; set; }
    }
}
