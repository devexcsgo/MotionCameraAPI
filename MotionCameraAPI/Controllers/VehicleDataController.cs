using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace MotionCameraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDataController : ControllerBase
    {
        private const string ApiToken = "HCXwBcZlDuEiDJXbqKbYOYpX78VL8lufQeVyiwB1Rl6gB5pGvBg1ImI1NWRz5LHB"; // Hentet API token

        // GET api/licenseplates/vehicledata/{plate}
        [HttpGet("vehicledata/{plate}")]
        public async Task<ActionResult> GetVehicleData(string plate)
        {
            // URL til 3. parts API
            string apiUrl = $"https://api.nrpla.de/{plate}?api_token={ApiToken}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = await response.Content.ReadAsStringAsync();
                        return Ok(jsonData); // Returnerer rå JSON data
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode, "Fejl ved hentning af data fra NummerpladeAPI");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"En fejl opstod: {ex.Message}");
            }
        }
    }
}