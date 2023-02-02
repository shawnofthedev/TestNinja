using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestNinja.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCustomer(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}
