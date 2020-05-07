using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        // POST: api/TodoItems
        [HttpGet]
        public string Foo()
        {
            return "OK";
        }

        // POST: api/TodoItems
        [HttpPost]
        [Route("api/v1/[controller]/Items")]
        public async Task<ActionResult<dynamic>> PostTodoItem()
        {
            return Ok(123);
        }
    }
}