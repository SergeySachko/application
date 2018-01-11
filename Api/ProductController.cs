using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class ProductController : ApplicationApiController
    {
        public ProductController()
        {

        }

        [Authorize]
        [HttpPost]
        [Route("api/Product/Add")]
        public IActionResult Add([FromBody]ProductDTO model)
        {
            return ReturnResponse(null);
        }

        [Authorize]
        [HttpGet]
        [Route("api/Product/Get")]
        public IActionResult Get([FromBody]ProductDTO model)
        {
            return ReturnResponse(null);
        }

        [Authorize]
        [HttpPut]
        [Route("api/Product/Put")]
        public IActionResult Put([FromBody]ProductDTO model)
        {
            return ReturnResponse(null);
        }

        [Authorize]
        [HttpPost]
        [Route("api/Product/Delete")]
        public IActionResult Delete([FromBody]ProductDTO model)
        {
            return ReturnResponse(null);
        }
    }
}
