using BBL.Extensions;
using BBLInterface;
using HtmlAgilityPack;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace BBL
{
    public class ParserService : IParserService
    {
       
        public OperationResult ParseByPage(string pageUrl)
        {
            throw new NotImplementedException();
        }

        public OperationResult ParseByUrl(string url)
        {
            ProductDTO result = null;          

            HtmlDocument html = new HtmlDocument();

            var htmlStr = new WebClient().DownloadString(url);
            html.LoadHtml(htmlStr);

            if (url.Contains("aliexpress"))
                result = new AliExpressParser().ParseAliexpressPage(html);                

            if(result == null)
            {
                return new OperationResult()
                {
                    IsSucceded = false,
                    ErrorMessage = "Page was not found"
                };
            }

            result.ProductBaseUrl = url;

            return new OperationResult()
            {
                IsSucceded = true,
                Result = result
            };
        }

        
    }
}
