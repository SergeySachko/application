using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductBaseUrl { get; set; }

        public int ProductTypeId { get; set; }
        
        public int ProductCategoryId { get; set; }

        public bool IsVisible { get; set; }

        public byte StrockStatus { get; set; }

        public double RegularPrice { get; set; }

        public double? SalePrice { get; set; }

        public short? SalePercent { get; set; }

        public double? Price { get; set; }

        public double? Weight { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        public double? Height { get; set; }

        public DateTime? SalePriceDateFrom { get; set; }

        public DateTime? SalePriceDateTo { get; set; }

        public string ImageURL { get; set; }
        

        [NotMapped]
        public string VisibilityStr
        {
            get
            {
                return IsVisible ? "visible" : "hidden";
            }
        }

        [NotMapped]
        public string StrockStatusStr
        {
            get
            {
                switch (StrockStatus)
                {
                    case (byte)StockStatus.InStock:
                        return "instock";

                    case (byte)StockStatus.OutOfStock:
                        return "outofstock";

                    case (byte)StockStatus.OnRequest:
                        return "onrequest";
                    default:
                        return null;
                }
            }
        }
    }

    public enum StockStatus
    {
        InStock = 1,
        OutOfStock = 2,
        OnRequest = 3
    }
}
