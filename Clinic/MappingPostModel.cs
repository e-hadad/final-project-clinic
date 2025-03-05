using AutoMapper;
using clinic.Models;
using Clinic.Core.Entities;

namespace clinic
{
    public class MappingPostModel : Profile
    {
        public MappingPostModel() 
        {
            CreateMap<DoctorModel, DoctorClass>().ReverseMap();
            CreateMap<PatientModel, PatientClass>().ReverseMap();
            CreateMap<RouteModel, RoutesClass>().ReverseMap();
        }
        
    }
}
