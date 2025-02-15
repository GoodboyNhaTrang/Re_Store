using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BasicApiController
    {
        [HttpGet("not-found")]

        public ActionResult GetNotFound()
        {
            return NotFound();
        }
        
        [HttpGet("bad-request")]
         public ActionResult GetBadRequest()
        {
            return BadRequest(new ProblemDetails{Title="This is a bad request"});
        
        }

        [HttpGet("unauthorized")]
         public ActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        [HttpGet("validation-error")]
         public ActionResult GetValidation()
        {
            ModelState.AddModelError("Problem1", "This is first error");
            ModelState.AddModelError("Problem2", "This is second error");
            return ValidationProblem();
        }

        [HttpGet("server-error")]
         public ActionResult GetServerError()
        {
            throw new Exception("This is a server error");
        }

    }
}