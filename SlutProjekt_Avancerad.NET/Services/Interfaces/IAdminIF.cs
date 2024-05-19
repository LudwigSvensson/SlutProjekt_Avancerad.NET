using ClassModels;
using Microsoft.AspNetCore.Mvc;
using SlutProjekt_ClassLibrary;

namespace SlutProjekt_Avancerad.NET.Services.Interfaces
{
    public interface IAdminIF<T>
    {
        Task<Appointment> GetAppointmentByID(int id);
        Task<Appointment> AddAppointment(Appointment appointment);
        Task<Appointment> UpdateAppointment(Appointment entity);
        Task<Appointment> DeleteAppointment(int id);

        Task<Customer> GetCustomer(int id);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int id);
        Task<IEnumerable<Appointment>> SearchAppointmentsByDateRange(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] string sort = "date_desc");
        Task<IEnumerable<AppointmentHistory>> GetAllHistoricalAppointments();
    }
}
