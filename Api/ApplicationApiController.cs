using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class ApplicationApiController : Controller
    {
        protected IActionResult ReturnResponse(OperationResult result)
        {
            if (result.IsSucceded)
            {
                if (result.Result != null)
                    return Ok(result.Result);
                else
                    return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
            }

        }
    }
}
