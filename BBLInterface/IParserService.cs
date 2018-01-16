using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBLInterface
{
    public interface IParserService
    {
        OperationResult ParseByUrl(string url);

        OperationResult ParseByPage(string pageUrl);
    }
}
