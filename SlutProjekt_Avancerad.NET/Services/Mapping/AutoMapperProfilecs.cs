using ClassModels;
using AutoMapper;
using SlutProjekt_ClassLibrary;

namespace SlutProjekt_Avancerad.NET.Services.Mapping
{
    public class AutoMapperProfilecs : Profile
    {
        public AutoMapperProfilecs()
        {
            CreateMap<Appointment, AppointmentHistory>();
        }
    }
}
