using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Services
{
    public interface IDoctorService
    {
     
        public  Task<IEnumerable<DoctorClass>> GetDoctorAsync();
        public  Task<DoctorClass> GetDoctorByIdAsync(int id);
        public  Task<DoctorClass> AddDoctorAsync(DoctorClass doctor);
        public  Task UpdateDoctorAsync(int id, DoctorClass doctor);
        public  Task DeleteDoctorAsync(int id);
    }
}
