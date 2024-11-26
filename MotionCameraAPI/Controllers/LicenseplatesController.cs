using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MotionCameraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseplatesController : ControllerBase
    {

        private LicensePlateRepository _licensePlateRepository;

        public LicenseplatesController(LicensePlateRepository licensePlateRepository)
        {
            _licensePlateRepository = licensePlateRepository;
        }


        // GET: api/<SchoolsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<LicensePlate>> Get()
        {
            IEnumerable<LicensePlate> licensePlate = _licensePlateRepository.GetAll();
            if (licensePlate == null)
            {
                return NotFound();
            }
            return Ok(licensePlate);
        }

        // GET api/<SchoolsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<LicensePlate> Get(int id)
        {
            LicensePlate licensePlate = _licensePlateRepository.Get(id);
            if (licensePlate == null)
            {
                return NotFound();
            }
            return Ok(licensePlate);
        }

        // POST api/<SchoolsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost]
        public ActionResult<LicensePlate> Post([FromBody] LicensePlate newLicensePlate)
        {
            try
            {
                LicensePlate createdLicensePlate = _licensePlateRepository.Add(newLicensePlate);
                return Created("/" + createdLicensePlate.Id, createdLicensePlate);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT api/<LicenseplatesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LicenseplatesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<LicensePlate> Delete(int id) 
        {
            var licensePlate = _licensePlateRepository.Remove(id);
            if (_licensePlateRepository.Get(id) == null)
            {
                return NotFound();
            }      
            return Ok(licensePlate);
        }
    }
}
