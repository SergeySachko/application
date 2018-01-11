using BBLInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
     public class ParseController : ApplicationApiController
    {
        private readonly IParserService parserService;

        public ParseController(IParserService _parserService)
        {
            parserService = _parserService
        }

        [Authorize]
        [HttpPost]
        [Route("api/Parser/ByUrl")]
        public IActionResult ParseByUrl([FromBody]string parseUrl)
        {
            return ReturnResponse(parserService.AddProductByURL(parseUrl));
        }
    }
}
