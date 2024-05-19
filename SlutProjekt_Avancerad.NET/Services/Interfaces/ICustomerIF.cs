using ClassModels;
using Projekt_Avancerad.NET.Data;

namespace SlutProjekt_Avancerad.NET.Services.Interfaces
{
    public interface ICustomerIF<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> RecentAppointments();
        Task<Appointment> AddAppointment(Appointment newAppointment);
        Task<Appointment> UpdateAppointment(Appointment updatedAppointment);
        Task<Appointment> CancelAppointment(int customerId, int appointmentId);
        Task<Appointment> GetAppointment(int customerId, int appointmentId);
        
    }
}
