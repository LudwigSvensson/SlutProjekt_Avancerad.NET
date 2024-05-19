using AutoMapper;
using ClassModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Projekt_Avancerad.NET.Data;
using SlutProjekt_Avancerad.NET.Services.Interfaces;
using SlutProjekt_ClassLibrary;

namespace SlutProjekt_Avancerad.NET.Services.Repositories
{
    public class CustomerRepo : ICustomerIF<Customer> , IAppointmentHistoryIF<AppointmentHistory> 
    {
        private readonly IMapper _mapper;
        private AppDbContext _appDbContext;
        public CustomerRepo(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;

        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            var result = await _appDbContext.Appointments.AddAsync(appointment);
            await _appDbContext.SaveChangesAsync();
            
            return result.Entity;
        }

        public async Task<Appointment> CancelAppointment(int customerId, int appointmentId)
        {
            var result = await _appDbContext.Appointments.FindAsync(appointmentId);
            if (result == null || result.CustomerID != customerId)
            {
                throw new Exception("Appointment not found for the customer.");
            }

            var appointmentHistory = _mapper.Map<AppointmentHistory>(result);
            appointmentHistory.Action = "Deleted";
            appointmentHistory.NewData = null;
            appointmentHistory.OldData = result.ToString();
            appointmentHistory.ActionTimeStamp = DateTime.Now;

            // Spara AppointmentHistory-objektet
            _appDbContext.AppointmentHistories.Add(appointmentHistory);

            _appDbContext.Appointments.Remove(result);
            await _appDbContext.SaveChangesAsync();


            return result;
        }

        public async Task<Appointment> UpdateAppointment(Appointment appointment)
        {
            var result = await _appDbContext.Appointments
                .FirstOrDefaultAsync(a => a.ApointmentID == appointment.ApointmentID);
            if (result != null)
            {
                var appointmentHistory = _mapper.Map<AppointmentHistory>(result);
                appointmentHistory.AppointmentID = appointment.ApointmentID;
                appointmentHistory.Action = "Updated";
                appointmentHistory.NewData = JsonConvert.SerializeObject(result);
                appointmentHistory.OldData = JsonConvert.SerializeObject(appointment);
                appointmentHistory.ActionTimeStamp = DateTime.Now;

                // Spara historiken
                _appDbContext.AppointmentHistories.Add(appointmentHistory);

                result.AppointmentDate = appointment.AppointmentDate;
                result.AppointmentType = appointment.AppointmentType;

               
                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Customer>> RecentAppointments()
        {
            DateTime startOfWeek = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Monday));
            DateTime endOfWeek = startOfWeek.AddDays(6);

            var customersWithBookingsThisWeek = await _appDbContext.Customers
                .Include(c => c.Appointments)
                .Where(customer => customer.Appointments
                .Any(appointment => appointment.AppointmentDate >= startOfWeek && appointment.AppointmentDate <= endOfWeek))
                .ToListAsync();

            return customersWithBookingsThisWeek;
        }

        

        public async Task<Customer> Update(Customer entity)
        {
            var result = await _appDbContext.Customers.
                FirstOrDefaultAsync(c => c.CustomerID == entity.CustomerID);
            if (result != null)
            {
                result = entity;
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Customer> GetSingle(int id)
        {
            return await _appDbContext.Customers.Include(c => c.Appointments).SingleOrDefaultAsync(c => c.CustomerID == id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _appDbContext.Customers.Include(c => c.Appointments).ToListAsync();
        }

        public async Task<Appointment> GetAppointment(int customerId, int appointmentId)
        {
            var customer = await _appDbContext.Customers.FindAsync(customerId);

            if (customer == null)
            {
                return null; 
            }
            var appointment = await _appDbContext.Appointments
                .SingleOrDefaultAsync(a => a.CustomerID == customerId && a.ApointmentID == appointmentId);
            return appointment;
        }

        public async Task SaveAppointmentHistory(Appointment appointment, string action, string previousData, Appointment currentData)
        {
            var result = new AppointmentHistory
            {
                AppointmentID = appointment.ApointmentID,
                Action = action,
                ActionTimeStamp = DateTime.UtcNow,
                OldData = previousData,
                NewData = currentData != null ? JsonConvert.SerializeObject(currentData) : null
            };
            _appDbContext.AppointmentHistories.Add(result);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
