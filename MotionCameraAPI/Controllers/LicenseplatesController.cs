using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MotionCameraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseplatesController : ControllerBase
    {
        // GET: api/<LicenseplatesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LicenseplatesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LicenseplatesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LicenseplatesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LicenseplatesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
