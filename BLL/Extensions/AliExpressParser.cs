using HtmlAgilityPack;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BBL.Help;
using System.Text;

namespace BBL.Extensions
{
    internal class AliExpressParser
    {        

        public  AliExpressParser()
        {            
        }

        public ProductDTO ParseAliexpressPage(HtmlDocument document)
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
                product.Price = ParsePrice(document);

                //product.SalePrice = Double.Parse("");

                product.Description = ParseDetails(document);

                product.Attributes = ParseAttributes(document);

                // Get Regular price and parse it to double 
                //var regularPrice = document.DocumentNode.Descendants("span")
                //                                     .Where(d => d.Attributes.Contains("class")
                //                                      && d.Attributes["class"].Value.Contains("product-name"))
                //                                     .FirstOrDefault().InnerHtml;
                //product.RegularPrice = regularPrice.IndexOf("-") > 0 ? Double.Parse(regularPrice.Substring(0, regularPrice.IndexOf("-") + 1).Trim()) : Double.Parse(regularPrice);

                return product;

            }
            catch (Exception e)
            {
                return null;
                throw e;
            }


        }

        private string ParseDetails(HtmlDocument document)
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

        private double ParsePrice(HtmlDocument document)
        {
            string script = GetScript(document, "totalValue");

            //Get Variable in script , remove excess text
            string price = script.Substring(script.IndexOf("totalValue"), script.Length - script.IndexOf("totalValue") - 1);
            //Remove left part
            price = price.Substring(price.IndexOf('\"'), price.Length - price.IndexOf('\"'));
            //Remove right part
            price = price.Substring(0, price.IndexOf("}") - 1);
            //Remove left char 
            price = price.Substring(price.IndexOf('$') + 1, price.IndexOf("$") - 1);
            return Convert.ToDouble(price, CultureInfo.InvariantCulture);
        }

        private string GetScript(HtmlDocument document, string innerScriptVariable)
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

        private List<AttributeDTO> ParseAttributes(HtmlDocument document)
        {
            List<AttributeDTO> listAttributes = new List<AttributeDTO>();

            //Get Contai
            var productSto = document.DocumentNode
                                     .Descendants("div").Where(d => d.Attributes.Contains("id") && d.Attributes["id"].Value.Contains("j-product-info-sku")).FirstOrDefault()
                                     .Descendants("dl").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("p-property-item"));
            
            foreach (var item in productSto)
            {
                AttributeDTO attribute = new AttributeDTO()
                {
                    Name = item.Descendants("dt").Where(dt => dt.Attributes.Contains("class") && dt.Attributes["class"].Value.Contains("p-item-title"))
                                                 .FirstOrDefault().InnerText.Trim(':'),

                    Slug = TransliterationHelper.Front(item.Descendants("dt").Where(dt => dt.Attributes.Contains("class") && dt.Attributes["class"].Value.Contains("p-item-title"))
                                                                             .FirstOrDefault().InnerText).ToLower()
                };

                var variablesTag = item.Descendants("dd").Where(dd=>dd.Attributes.Contains("class") && dd.Attributes["class"].Value.Contains("p-item-main"))
                                                         .FirstOrDefault()
                                                         .Descendants("ul").FirstOrDefault().ChildNodes.Where(ch=>ch.Name == "li");

                List<AttributesTermDTO> variables = new List<AttributesTermDTO>();

                foreach(var variable in variablesTag)
                {
                    if (variable.InnerHtml.Contains("img"))
                    {
                        variables.Add(new AttributesTermDTO()
                        {
                            Name = variable.Descendants("a").FirstOrDefault().Attributes["title"].Value,

                            Slug = TransliterationHelper.Front(variable.Descendants("a").FirstOrDefault().Attributes["title"].Value).ToLower(),

                            ImageUrl = variable.Descendants("a").FirstOrDefault().Descendants("img").FirstOrDefault().Attributes["src"].Value
                        });
                    }
                    else
                    {
                        variables.Add(new AttributesTermDTO()
                        {
                            Name = variable.Descendants("a").Where(a => a.InnerHtml.Contains("span")).FirstOrDefault()?.Descendants("span").FirstOrDefault().InnerText,

                            Slug = TransliterationHelper.Front(variable.Descendants("a").Where(a => a.InnerHtml.Contains("span"))
                                                                                    .FirstOrDefault()?
                                                                                    .Descendants("span")
                                                                                    .FirstOrDefault().InnerText).ToLower()
                        });
                    }

                    
                }

                attribute.Terms = variables.Count > 0 ? variables : null;

                listAttributes.Add(attribute);
            }

            return listAttributes;
        }

    }
}
