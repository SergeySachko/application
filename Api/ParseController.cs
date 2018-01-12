using BBLInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
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
            parserService = _parserService;
        }

        
        [HttpPost]
        [Route("api/Parser/ByUrl")]
        public IActionResult ParseByUrl([FromBody]ParserRequest parserRequest)
        {
            return ReturnResponse(parserService.AddProductByURL(parserRequest.ProductUrl));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Parser/GetByUrl")]
        public IActionResult GetParseByUrl()
        {
            return ReturnResponse(new OperationResult() { IsSucceded = true, Result = "Parse" });
        }
    }
}
