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

                    /*SalePercent = short.Parse(document.DocumentNode.Descendants("span")
                                                      .Where(d => d.Attributes.Contains("class")
                                                       && d.Attributes["class"].Value.Contains("p-price"))
                                                      .FirstOrDefault().InnerHtml.Replace(@"-", "").Replace(@"%", "")),*/
                }; 
                var test = document.DocumentNode.Descendants("div")
                                                      .Where(d => d.Attributes.Contains("class")
                                                       && d.Attributes["class"].Value.Contains("product-price-main"))
                                                      .FirstOrDefault()
                                                      .Descendants("div")
                                                      .Where(d => d.Attributes.Contains("class")
                                                       && d.Attributes["class"].Value.Contains("p-current-price"))
                                                      .FirstOrDefault()
                                                      .Descendants("span")
                                                      .Where(d => d.Attributes.Contains("class")
                                                       && d.Attributes["class"].Value == "p-price")
                                                      .FirstOrDefault().InnerText;
                //product.SalePrice = Double.Parse("");
                product.ImageURL = document.DocumentNode.Descendants("a")
                                                      .Where(d => d.Attributes.Contains("class")
                                                       && d.Attributes["class"].Value.Contains("ui-image-viewer-thumb-frame"))
                                                      .FirstOrDefault()
                                                      .Descendants("img")
                                                      .FirstOrDefault()
                                                      .Attributes["src"].Value;
                product.Description = ParseDetails(document);

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

        private string ParseDetails(HtmlDocument document)
        {
            var scriptOfDetails = document.DocumentNode.Descendants().Where(d => d.Name.Contains("script")); ;
            string script = "";
            foreach (var item in scriptOfDetails)
            {
                if (item.InnerText.Contains("window.runParams.detailDesc"))
                {
                    script += item.InnerText.ToString();
                }

            }
            string modifiedScriptStr = script.Substring(script.IndexOf("window.runParams.detailDesc"), script.Length - script.IndexOf("window.runParams.detailDesc"));
            string detailUrl = modifiedScriptStr.Substring(modifiedScriptStr.IndexOf("=") + 1, modifiedScriptStr.IndexOf(";"));
            detailUrl = detailUrl.Substring(0, detailUrl.IndexOf(";"));

            var web = new HtmlWeb();
            var doc = web.Load(detailUrl.Trim('\"'));

            return doc.ParsedText;


        }
    }
}
