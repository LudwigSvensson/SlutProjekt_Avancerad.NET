using ClassModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Projekt_Avancerad.NET.Data;
using SlutProjekt_Avancerad.NET.Services.Interfaces;
using SlutProjekt_ClassLibrary;

namespace SlutProjekt_Avancerad.NET.Services.Repositories
{
    public class AppointmentHistoryRepo : IAppointmentHistoryIF<AppointmentHistory> 
    {
        private AppDbContext _appDbContext;
        public AppointmentHistoryRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<AppointmentHistory>> GetAllHistoricalAppointments()
        {
            return await _appDbContext.AppointmentHistories.ToListAsync();
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
    }
}
