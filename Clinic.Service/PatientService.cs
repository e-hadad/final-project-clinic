using Clinic.Core.Services;
using Clinic.Core.Repositories;
using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Service
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _repository;
        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<PatientClass>> GetPatientAsync()
        {
            return await _repository.GetAsync();
        }
        public async Task<PatientClass> GetPatientByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<PatientClass> AddPtientAsync(PatientClass patient)
        {
            return await _repository.AddAsync(patient);
        }
        
        public async Task  UpdatePatientAsync(int id, PatientClass patient)
        { 
            var PatientUp =await  _repository.GetAsync();
            var PatientUpTemp= PatientUp.FirstOrDefault(x => x.Id == id);
            if (PatientUpTemp != null)
                await _repository.UpdateAsync(id, patient);
        }
        public async Task DeletePatientAsync(int id)
        {
              var DelPatient =await  _repository.GetAsync();
              var DelPatientTemp = DelPatient.FirstOrDefault(x => x.Id == id);
              if (DelPatientTemp != null)
              {
                  await _repository.DeleteIdAsync(id); 
              }
        }
    }
}
