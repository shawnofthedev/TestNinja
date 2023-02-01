using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestNinja.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public User MadeBy { get; set; }

        [HttpPost]
        public async Task<IActionResult> CanBeCancelledBy(User user)
        {
            if(user.IsAdmin || MadeBy == user)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }                
        }
    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}
