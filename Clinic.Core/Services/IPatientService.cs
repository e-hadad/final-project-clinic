using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Services
{
    public interface IPatientService
    {
        
        public  Task<IEnumerable<PatientClass>> GetPatientAsync();
        public  Task<PatientClass> GetPatientByIdAsync(int id);
        public  Task<PatientClass> AddPtientAsync(PatientClass patient);
        public Task UpdatePatientAsync(int id, PatientClass patient);
        public Task DeletePatientAsync(int id);
    }
}
