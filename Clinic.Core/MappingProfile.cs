using AutoMapper;
using Clinic.Core.DTOs;
using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core
{
    public class MappingProfile : Profile
    {
       public MappingProfile() {
            CreateMap<PatientClass,PatientDTO>().ReverseMap();
            CreateMap<DoctorClass,DoctorDTO>().ReverseMap();
            CreateMap<RoutesClass,RouteDTO>().ReverseMap();
        }  

    }
}
