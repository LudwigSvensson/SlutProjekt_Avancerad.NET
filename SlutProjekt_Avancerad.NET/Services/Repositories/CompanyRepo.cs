using ClassModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Projekt_Avancerad.NET.Data;
using SlutProjekt_Avancerad.NET.Services.Interfaces;
using SlutProjekt_ClassLibrary;

namespace SlutProjekt_Avancerad.NET.Services.Repositories
{
    public class CompanyRepo : IAdminIF<Company> , IAppointmentHistoryIF<AppointmentHistory>
    {
        private AppDbContext _appDbContext;
        public CompanyRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Customer> AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
        public Task<Customer> DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var result = await _appDbContext.Customers
                .FirstOrDefaultAsync(c=>c.CustomerID == customer.CustomerID);
            if (result != null)
            {
                result.CustomerName = customer.CustomerName;
                result.CustomerEmail = customer.CustomerEmail;

                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
            
        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            var result = await _appDbContext.Appointments.AddAsync(appointment);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Appointment> DeleteAppointment(int id)
        {
            var appointment = await _appDbContext.Appointments.FindAsync(id);
            if (appointment == null )
            {
                throw new Exception("Appointment not found");
            }
            var oldData = JsonConvert.SerializeObject(appointment);
            await SaveAppointmentHistory(appointment, "Deleted", oldData, null);
            _appDbContext.Appointments.Remove(appointment);
            await _appDbContext.SaveChangesAsync();

            return appointment;
        }
        public async Task<Appointment> GetAppointmentByID(int id)
        {
            return await _appDbContext.Appointments.SingleOrDefaultAsync(a => a.ApointmentID == id);
        }
        public async Task<Appointment> UpdateAppointment(Appointment appointment)
        {
            var result = await _appDbContext.Appointments
                .FirstOrDefaultAsync(a => a.ApointmentID == appointment.ApointmentID);
            if (result != null)
            {
                var oldData = JsonConvert.SerializeObject(result);
                var resultCopy = JsonConvert.DeserializeObject<Appointment>(oldData);

                result.AppointmentDate = appointment.AppointmentDate;
                result.AppointmentType = appointment.AppointmentType;

                await SaveAppointmentHistory(appointment, "Updated", oldData, result);
                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _appDbContext.Customers.SingleOrDefaultAsync(c =>c.CustomerID == id);
        }
        public async Task<IEnumerable<Appointment>> SearchAppointmentsByDateRange(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] string sort = "date_desc")
        {
            
            IQueryable<Appointment> query = _appDbContext.Appointments;

            // Applicera sökkriterier baserat på användarens inmatning
            if (startDate.HasValue)
            {
                query = query.Where(a => a.AppointmentDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(a => a.AppointmentDate <= endDate.Value);
            }

            switch (sort)
            {
                case "date_asc":
                    query = query.OrderBy(a => a.AppointmentDate);
                    break;
                case "date_desc":
                    query = query.OrderByDescending(a => a.AppointmentDate);
                    break;
                default:
                    query = query.OrderByDescending(a => a.AppointmentDate);
                    break;
            }

            var appointments = await query.ToListAsync();
            return appointments;
        }

        public async Task SaveAppointmentHistory(Appointment appointment, string action, string previousData, Appointment currentData)
        {
            var historyEntry = new AppointmentHistory
            {
                AppointmentID = appointment.ApointmentID,
                Action = action,
                ActionTimeStamp = DateTime.UtcNow,
                OldData = previousData,
                NewData = currentData != null ? JsonConvert.SerializeObject(currentData) : null
            };
            _appDbContext.AppointmentHistories.Add(historyEntry);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<AppointmentHistory>> GetAllHistoricalAppointments()
        {
            return await _appDbContext.AppointmentHistories.ToListAsync();
        }
    }
}
