using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Interface;

namespace WebApplication2.Controller
{
    [Route("sushis")]
    [ApiController]
    [EnableCors]
    public class SushiController : ControllerBase
    {
        
        private readonly ISushiService _sushiService;

        public SushiController(ISushiService sushiService)
        {
            _sushiService = sushiService;
        }

        [HttpGet]
        public IActionResult GetSushis()
        {
            try
            {
                Console.WriteLine("Testing");
               // return Ok("HelloData");
                return Ok(_sushiService.GetSushis());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}