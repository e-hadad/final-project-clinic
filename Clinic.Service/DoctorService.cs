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
    public class DoctorService: IDoctorService
    {
        private IDoctorRepository _repository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _repository = doctorRepository;
        } 
        public async Task<IEnumerable<DoctorClass>> GetDoctorAsync()
        {
            return await _repository.GetAsync();
        }
        public async Task<DoctorClass> GetDoctorByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<DoctorClass> AddDoctorAsync(DoctorClass doctor)
        {

            return await _repository.AddAsync(doctor);
        }
        public async Task UpdateDoctorAsync(int id,DoctorClass doctor)
        {
            var DoctorUp = await _repository.GetAsync();
            var DoctorUpTemp=DoctorUp.FirstOrDefault(x => x.Id == id);
            if (DoctorUpTemp != null)
                 await _repository.UpdateAsync(id,doctor);
        }
        public async Task DeleteDoctorAsync(int id)
        {
             var DelDoctor=await _repository.GetAsync();
             var DelDoctorTemp= DelDoctor.FirstOrDefault(x => x.Id == id);
             if (DelDoctorTemp != null)
             {
                 await _repository.DeleteIdAsync(id);
             }              
        }
    }
}
