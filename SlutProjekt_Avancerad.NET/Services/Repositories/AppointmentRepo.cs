using ClassModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Projekt_Avancerad.NET.Data;
using SlutProjekt_Avancerad.NET.Services.Interfaces;
using System;

namespace SlutProjekt_Avancerad.NET.Services.Repositories
{
    public class AppointmentRepo : IAppIF<Appointment>
    {
        private AppDbContext _appDbContext;
        public AppointmentRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Appointment> Add(Appointment newEntity)
        {
            var result = await _appDbContext.Appointments.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Appointment> Delete(int id)
        {
            var result = await _appDbContext.Appointments.SingleOrDefaultAsync
              (a => a.ApointmentID == id);
            if (result != null)
            {
                var previousData = JsonConvert.SerializeObject(result);
                
                _appDbContext.Appointments.Remove(result);
                await _appDbContext.SaveChangesAsync();

                
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _appDbContext.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetSingle(int id)
        {
            return await _appDbContext.Appointments.SingleOrDefaultAsync(a => a.ApointmentID == id);
        }

        public async Task<Appointment> Update(Appointment entity)
        {
            var result = await _appDbContext.Appointments.
               FirstOrDefaultAsync(a => a.ApointmentID == entity.ApointmentID);
            if (result != null)
            {
                result = entity;
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
