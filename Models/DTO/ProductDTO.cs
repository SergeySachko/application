using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class ProductDTO : SEOModel
    {
        public int Id { get; set; }

        // TODO: Change Type 
        public string ProductType { get; set; }

        // TODO: Change Type 
        public string ProductCategory { get; set; }

        public string Title { get; set; }

        public string VisibilityStr { get; set; }

        //TODO : Change Name
        public string StrockStatusStr { get; set; }

        public double RegularPrice { get; set; }

        public double SalePrice { get; set; }

        public short SalePercent { get; set; } 

        public double? Price { get; set; }

        public double? Weight { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        public double? Height { get; set; }

        public DateTime? SalePriceDateFrom { get; set; }

        public DateTime? SalePriceDateTo { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
    }
}
