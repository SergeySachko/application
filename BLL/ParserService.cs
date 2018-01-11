using BBLInterface;
using HtmlAgilityPack;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBL
{
    public class ParserService : IParserService
    {
        public OperationResult AddProductByURL(string url)
        {
            return ParseByUrl(url);
        } 

        public OperationResult AddProductsByPage(string pageUrl)
        {
            throw new NotImplementedException();
        }

        private OperationResult ParseByUrl(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);


            return null; 
        }

        private ProductDTO ParseAliexpressPage(HtmlDocument document)
        {
            ProductDTO product = new ProductDTO
            {
                Title = document.DocumentNode.Descendants("h1")
                                                  .Where(d => d.Attributes.Contains("class")
                                                   && d.Attributes["class"].Value.Contains("product-name"))
                                                  .FirstOrDefault().InnerHtml,
                SalePrice = Double.Parse(document.DocumentNode.Descendants("span")
                                                  .Where(d => d.Attributes.Contains("class")
                                                   && d.Attributes["class"].Value.Contains("p-price"))
                                                  .FirstOrDefault().InnerHtml),

                SalePercent = short.Parse(document.DocumentNode.Descendants("span")
                                                  .Where(d => d.Attributes.Contains("class")
                                                   && d.Attributes["class"].Value.Contains("p-price"))
                                                  .FirstOrDefault().InnerHtml),
            };


            // Get Regular price and parse it to double 
            var regularPrice = document.DocumentNode.Descendants("span")
                                                 .Where(d => d.Attributes.Contains("class")
                                                  && d.Attributes["product-name"].Value.Contains("header-content-title"))
                                                 .FirstOrDefault().InnerHtml;
            product.RegularPrice = Double.Parse(regularPrice.Substring(0, regularPrice.IndexOf("-") + 1).Trim());



            return null;
        }
    }
}
