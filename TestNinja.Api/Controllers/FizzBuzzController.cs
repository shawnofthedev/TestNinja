using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestNinja.Lib;
using TestNinja.Lib.Interfaces;

namespace TestNinja.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        private IFizzBuzz _fizzBuzz;

        public FizzBuzzController(IFizzBuzz fizzBuzz)
        {
            _fizzBuzz = fizzBuzz;
        }

        [HttpGet] 
        public IActionResult GetFizzBuzz(int limit)
        {
            if(limit <= 0)
            {
                var exception = new ArgumentException("Interger must be greater than zero");
                return BadRequest(exception);
            }

            List<string> list = new List<string>();
            for(int i = 0; i < limit; i++)
            {
                list.Add(_fizzBuzz.GetOutput(i));
            }
            return Ok(list);
        }
    }
}
