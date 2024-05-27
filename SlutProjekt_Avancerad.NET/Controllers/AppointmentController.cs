using ClassModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlutProjekt_Avancerad.NET.Services.Interfaces;

namespace SlutProjekt_Avancerad.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppIF<Appointment> _appointment;
        public AppointmentController(IAppIF<Appointment> appointment)
        {
            _appointment = appointment;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> GetAllAppointments()
        {
            try
            {
                var result = await _appointment.GetAll();
                if (result == null)
                {
                    return NotFound("Can't find any appointments");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }
    }
}
