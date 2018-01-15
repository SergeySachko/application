using BBLInterface;
using HtmlAgilityPack;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
            ProductDTO result = null;
            var web = new HtmlWeb();
            var doc = web.Load(url);

            if (url.Contains("aliexpress"))
                result = ParseAliexpressPage(doc);
            

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

                    ImageURL = document.DocumentNode.Descendants("a")
                                                      .Where(d => d.Attributes.Contains("class")
                                                       && d.Attributes["class"].Value.Contains("ui-image-viewer-thumb-frame"))
                                                      .FirstOrDefault()
                                                      .Descendants("img")
                                                      .FirstOrDefault()
                                                      .Attributes["src"].Value

                /*SalePercent = short.Parse(document.DocumentNode.Descendants("span")
                                                  .Where(d => d.Attributes.Contains("class")
                                                   && d.Attributes["class"].Value.Contains("p-price"))
                                                  .FirstOrDefault().InnerHtml.Replace(@"-", "").Replace(@"%", "")),*/
            };
                product.Price = ParseAliexpressPrice(document);

                //product.SalePrice = Double.Parse("");


                product.Description = ParseAliexpressDetails(document);

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
       
        private string ParseAliexpressDetails(HtmlDocument document)
        {
            string script = GetScript(document, "window.runParams.detailDesc");

            //Get details url
            string modifiedScriptStr = script.Substring(script.IndexOf("window.runParams.detailDesc"), script.Length - script.IndexOf("window.runParams.detailDesc"));
            string detailUrl = modifiedScriptStr.Substring(modifiedScriptStr.IndexOf("=") + 1, modifiedScriptStr.IndexOf(";"));
            detailUrl = detailUrl.Substring(0, detailUrl.IndexOf(";"));

            var web = new HtmlWeb();
            var doc = web.Load(detailUrl.Trim('\"'));

            return doc.ParsedText;
        }

        private double ParseAliexpressPrice(HtmlDocument document)
        {
            string script = GetScript(document, "totalValue");

            //Get Variable in script , remove excess text
            string price = script.Substring(script.IndexOf("totalValue"),script.Length - script.IndexOf("totalValue") - 1);
            //Remove left part
            price = price.Substring(price.IndexOf('\"'), price.Length - price.IndexOf('\"'));
            //Remove right part
            price = price.Substring(0, price.IndexOf("}") - 1);
            //Remove left char 
            price = price.Substring(price.IndexOf('$') + 1, price.IndexOf("$") - 1);
            return  Convert.ToDouble(price, CultureInfo.InvariantCulture);
        }

        private string GetScript(HtmlDocument document,string innerScriptVariable)
        {
            var scriptOfDetails = document.DocumentNode.Descendants().Where(d => d.Name.Contains("script")); ;
            string script = "";
            foreach (var item in scriptOfDetails)
            {
                if (item.InnerText.Contains(innerScriptVariable))
                {
                    script += item.InnerText.ToString();
                }
            }
            return script;
        }
    }
}
