using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBLInterface
{
    public interface IParserService
    {
        OperationResult AddProductByURL(string url);

        OperationResult AddProductsByPage(string pageUrl);
    }
}
