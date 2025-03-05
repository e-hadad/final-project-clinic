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
        /* public IEnumerable<PatientClass> GetPatientAsync();
         public PatientClass GetPatientByIdAsync(int id);
         public void UpdatePatientAsync(int id, PatientClass patient);

         public PatientClass AddPtientAsync(PatientClass patient);
         public void DeletePatientAsync(int id);*/
        public  Task<IEnumerable<PatientClass>> GetPatientAsync();
        public  Task<PatientClass> GetPatientByIdAsync(int id);
        public  Task<PatientClass> AddPtientAsync(PatientClass patient);
        public Task UpdatePatientAsync(int id, PatientClass patient);
        public Task DeletePatientAsync(int id);
    }
}
