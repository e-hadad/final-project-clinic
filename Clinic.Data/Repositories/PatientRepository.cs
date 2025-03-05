using Clinic.Core.Entities;
using clinic;
using Clinic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Repositories
{
    public class PatientRepository: IPatientRepository
    {
        private DataContext _dataContext;
        public PatientRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<PatientClass>> GetAsync()
        {
            return await _dataContext.ListPatient.ToListAsync();
        }

        public async Task<PatientClass> GetByIdAsync(int id)
        {
            var PatientId = _dataContext.ListPatient.FirstOrDefaultAsync(x => x.Id == id);
            if (PatientId == null)
                return null;
            return await PatientId;
        }
        public async Task<PatientClass> AddAsync(PatientClass patient)
        {
            _dataContext.ListPatient.AddAsync(patient);
            await _dataContext.SaveChangesAsync();
            return  patient;
        }
        public async Task UpdateAsync(int id,PatientClass patient)
        {
            var Patient = _dataContext.ListPatient.FirstOrDefault(x => x.Id == id);
            Patient.Name= patient.Name;
            Patient.Email= patient.Email;
            Patient.Phone= patient.Phone;
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteIdAsync(int id)
        {
            var patient = _dataContext.ListPatient.FirstOrDefault(x => x.Id == id);
            _dataContext.ListPatient.Remove(patient);
            await _dataContext.SaveChangesAsync();

        }
    }
}
