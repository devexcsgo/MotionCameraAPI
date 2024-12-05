using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MotionCameraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseplatesController : ControllerBase
    {

        private LicensePlateRepositoryDB _licensePlateRepository;

        public LicenseplatesController(LicensePlateRepositoryDB licensePlateRepository)
        {
            _licensePlateRepository = licensePlateRepository;
        }


        // GET ALL: api/<LicensePlatesController>
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

        // GET api/<LicensePlatesController>/5
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

        // POST (Add) api/<LicensePlatesController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        // DELETE (Remove) api/<LicenseplatesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<LicensePlate> Delete(int id) 
        {
            if (_licensePlateRepository.Get(id) == null)
            {
                return NotFound();
            }
            var licensePlate = _licensePlateRepository.Remove(id);
            return Ok(licensePlate);
        }
    }
}
