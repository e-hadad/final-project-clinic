using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Repositories
{
    public interface IPatientRepository
    {
        public  Task<IEnumerable<PatientClass>> GetAsync();
        public  Task<PatientClass> GetByIdAsync(int id);
        public  Task<PatientClass> AddAsync(PatientClass patient);
        public  Task UpdateAsync(int id, PatientClass patient);
        public  Task DeleteIdAsync(int id);

    }
}
