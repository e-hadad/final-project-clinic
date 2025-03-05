using clinic;
using Clinic.Core.Entities;
using Clinic.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private DataContext _dataContext;
        public DoctorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<DoctorClass>> GetAsync()
        {
            return  await _dataContext.ListDoctors.Include(d=>d.Routess).ToListAsync();
        }
       
        public async Task<DoctorClass> GetByIdAsync(int id)
        {
            var doctorId = _dataContext.ListDoctors.FirstOrDefaultAsync(x => x.Id == id);
            if (doctorId == null)
                return null;
            return await doctorId;
        }
        public async Task<DoctorClass> AddAsync(DoctorClass doctor)
        {
            _dataContext.ListDoctors.AddAsync(doctor);
            await _dataContext.SaveChangesAsync();
            return doctor;
            
        }
        public async Task UpdateAsync(int id,DoctorClass doctor)
        {
            var Doctor = _dataContext.ListDoctors.FirstOrDefault(x => x.Id == id);
            Doctor.Name = doctor.Name;
            Doctor.Phone = doctor.Phone;
            Doctor.Email = doctor.Email;
            await _dataContext.SaveChangesAsync();
        }
         public async Task DeleteIdAsync(int id)
        {
            var doctor = _dataContext.ListDoctors.FirstOrDefault(x => x.Id == id);
            _dataContext.ListDoctors.Remove(doctor);
            await _dataContext.SaveChangesAsync();

        }
    }
}
