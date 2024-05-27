using ClassModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Avancerad.NET.Data;
using SlutProjekt_Avancerad.NET.Services.Interfaces;
using System.Globalization;

namespace SlutProjekt_Avancerad.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerIF<Customer> _customer;
        public CustomerController(ICustomerIF<Customer> customer)
        {
            _customer = customer;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            try
            {
                var result = await _customer.GetAll();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("{id:int}/Get Info On Customer By Specific CustomerID/")]
        public async Task<ActionResult<List<Customer>>> GetSpecificCustomer(int id)
        {
            try
            {
                var result = await _customer.GetSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }
        [HttpGet("{customerID:int}/Get How Many Bookings A Customer Have In A Specific Week/{weekNumber:int}")]
        public async Task<ActionResult<int>> GetNumberOfBookingsForCustomerInWeek(int customerID, int weekNumber)
        {
            try
            {
                var bookings = await _customer.GetSingle(customerID);
                if (bookings == null)
                {
                    return BadRequest();
                }
                var bookingsInWeek = bookings.Appointments
                    .Where(b => b.AppointmentDate.Year == DateTime.Now.Year &&
                    CultureInfo.CurrentCulture.Calendar
                    .GetWeekOfYear(b.AppointmentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) == weekNumber);
               
                var numberOfBookings = bookingsInWeek.Count();

                return Ok(numberOfBookings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("/Get Customers By Their Recent Bookings/")]
        public async Task<ActionResult<List<Customer>>> GetRecentCustomers()
        {
            try
            {
                var result = await _customer.RecentAppointments();
                if (result == null || !result.Any())
                {
                    return NotFound("No customers with booking the recent week");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }

        }

        [HttpPost("{customerID:int}/Create New Appointment/")]
        public async Task<ActionResult<Appointment>> BookNewAppointment(int customerID, Appointment newAppointment)
        {
            try
            {
                var customer = await _customer.GetSingle(customerID);

                if (customer == null)
                {
                    return NotFound($"Customer with ID {customerID} not found..");
                }
                newAppointment.CustomerID = customerID;

                var appointment = await _customer.AddAppointment(newAppointment);

                return CreatedAtAction(nameof(BookNewAppointment), new { id = newAppointment.ApointmentID }, newAppointment);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error to Post Data To Database.......{ex.Message}{ex.InnerException}");
            }
        }

        [HttpPut("{customerId:int}/Update Appointment/{appointmentId:int}")]
        public async Task<ActionResult<Appointment>> UpdateAppointment(int customerId, int appointmentId, Appointment updatedAppointment)
        {
            try
            {
                var customer = await _customer.GetSingle(customerId);
                if (customer == null)
                {
                    return NotFound($"Customer with ID {customerId} not found.");
                }

                var appointment = await _customer.GetAppointment(customerId, appointmentId);
                if (appointment == null)
                {
                    return NotFound($"Appointment with ID {appointmentId} not found for customer with ID {customerId}.");
                }

                if (appointment.CustomerID != customerId)
                {
                    return Unauthorized("You are not authorized to update this appointment.");
                }

                appointment.AppointmentDate = updatedAppointment.AppointmentDate;
                appointment.AppointmentType = updatedAppointment.AppointmentType;
                
                await _customer.UpdateAppointment(appointment);
                return Ok(updatedAppointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message} {ex.InnerException.Message}");
            }
        }

        [HttpDelete("{customerId:int}/Cancel Appointment/{appointmentId:int}")]
        public async Task<ActionResult<Appointment>> CancelAppointment(int customerId, int appointmentId)
        {
            try
            {
                var appointment = await _customer.CancelAppointment(customerId, appointmentId);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message} {ex.InnerException.Message}");
            }
        }
    }
}
