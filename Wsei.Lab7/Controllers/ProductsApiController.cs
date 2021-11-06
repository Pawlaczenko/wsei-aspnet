using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Wsei.Lab7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Wsei.Lab7.Controllers
{
    [Route("api/products")]
    public class ProductsApiController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(ProductModel product)
        {
            return Ok();
        }
    }
}
