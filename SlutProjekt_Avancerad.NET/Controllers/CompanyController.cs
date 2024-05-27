using ClassModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SlutProjekt_Avancerad.NET.Services.Interfaces;
using SlutProjekt_ClassLibrary;

namespace SlutProjekt_Avancerad.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IAdminIF<Company> _company;
        public CompanyController(IAdminIF<Company> company)
        {
            _company = company;

        }


        [Authorize]
        [HttpPut("{appointmentId:int}/Update Appointment/")]
        public async Task<ActionResult<Appointment>> UpdateAppointment(int appointmentId, Appointment updatedAppointment)
        {
            try
            {

                var appointment = await _company.GetAppointmentByID(appointmentId);
                if (appointment == null)
                {
                    return NotFound($"Appointment with ID {appointmentId}... ");
                }

                appointment.AppointmentDate = updatedAppointment.AppointmentDate;
                appointment.AppointmentType = updatedAppointment.AppointmentType;

                await _company.UpdateAppointment(appointment);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete("{appointmentId:int}/Delete Appointment/")]
        public async Task<ActionResult<Appointment>> CancelAppointment(int appointmentId)
        {
            try
            {
                var appointment = await _company.DeleteAppointment(appointmentId);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [Authorize]
        [HttpPost("{customerID:int}/Create New Appointment For A Specific Customer/")]
        public async Task<ActionResult<Appointment>> BookNewAppointment(int customerID, Appointment newAppointment)
        {
            try
            {

                var customer = await _company.GetCustomer(customerID);

                if (customer == null)
                {
                    return NotFound($"Customer with ID {customerID} not found..");
                }
                newAppointment.CustomerID = customerID;

                var appointment = await _company.AddAppointment(newAppointment);

                return CreatedAtAction(nameof(BookNewAppointment), new { id = newAppointment.ApointmentID }, newAppointment);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to Post Data To Database.......{ex.Message}{ex.InnerException}");
            }
        }

        [Authorize]
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Appointment>>> SearchAppointments(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var appointments = await _company.SearchAppointmentsByDateRange(startDate, endDate);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                // Hantera eventuella fel och returnera lämpligt felmeddelande
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("Get All Historically changed bookings")]
        public async Task<ActionResult<IEnumerable<AppointmentHistory>>> GetAppointmentHistory()
        {
            try
            {
                var appointments = await _company.GetAllHistoricalAppointments();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                // Hantera eventuella fel och returnera lämpligt felmeddelande
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }
    }
}
