using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Repositories
{
    public interface IDoctorRepository
    {
        public  Task<IEnumerable<DoctorClass>> GetAsync();
        public  Task<DoctorClass> GetByIdAsync(int id);

        public  Task<DoctorClass> AddAsync(DoctorClass doctor);
        public  Task UpdateAsync(int id, DoctorClass doctor);
        public  Task DeleteIdAsync(int id);

    }
}
