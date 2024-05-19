using ClassModels;
using SlutProjekt_ClassLibrary;

namespace SlutProjekt_Avancerad.NET.Services.Interfaces
{
    public interface IAppointmentHistoryIF <T>
    {
        Task SaveAppointmentHistory(Appointment appointment, string action, string previousData, Appointment currentData);
    }
}
