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

            var result = ParseAliexpressPage(doc);

            if(result == null)
            {
                return new OperationResult()
                {
                    IsSucceded = false,
                    ErrorMessage = "Parse wasn't success"
                };
            }

            return new OperationResult()
            {
                IsSucceded = true,
                Result = result
            };
        }

        private ProductDTO ParseAliexpressPage(HtmlDocument document)
        {
            try
            {


                ProductDTO product = new ProductDTO
                {
                    Title = document.DocumentNode.Descendants("h1")
                                                      .Where(d => d.Attributes.Contains("class")
                                                       && d.Attributes["class"].Value.Contains("product-name"))
                                                      .FirstOrDefault().InnerHtml,
                    /*SalePrice = Double.Parse(document.DocumentNode.Descendants("span")
                                                      .Where(d => d.Attributes.Contains("class")
                                                       && d.Attributes["class"].Value.Contains("p-price"))
                                                      .FirstOrDefault().InnerHtml),

                    SalePercent = short.Parse(document.DocumentNode.Descendants("span")
                                                      .Where(d => d.Attributes.Contains("class")
                                                       && d.Attributes["class"].Value.Contains("p-price"))
                                                      .FirstOrDefault().InnerHtml.Replace(@"-", "").Replace(@"%", "")),

                    ImageURL = document.DocumentNode.Descendants("a")
                                                      .Where(d => d.Attributes.Contains("class")
                                                       && d.Attributes["class"].Value.Contains("ui-image-viewer-thumb-frame"))
                                                      .FirstOrDefault()
                                                      .Descendants("img")
                                                      .FirstOrDefault()
                                                      .Attributes["href"].Value,*/                   

                };

                var description = document.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("class")
                                                       && d.Attributes["class"].Value.Contains("buyer-protection-banner"))
                                                       .Select(s=>s.ChildNodes.Descendants("script"));


                var resultDescription = "";

               
                product.Description = resultDescription;

                // Get Regular price and parse it to double 
                //var regularPrice = document.DocumentNode.Descendants("span")
                //                                     .Where(d => d.Attributes.Contains("class")
                //                                      && d.Attributes["class"].Value.Contains("product-name"))
                //                                     .FirstOrDefault().InnerHtml;
                //product.RegularPrice = regularPrice.IndexOf("-") > 0 ? Double.Parse(regularPrice.Substring(0, regularPrice.IndexOf("-") + 1).Trim()) : Double.Parse(regularPrice);

                return product;

            }
            catch(Exception e)
            {
                return null;
                throw e;
            }

           
        }
    }
}
