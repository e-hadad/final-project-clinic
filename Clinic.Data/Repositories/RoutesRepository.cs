using Clinic.Core.Entities;
using clinic;
using Clinic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Clinic.Data.Repositories
{
    public class RoutesRepository : IRoutesRepository

    {
        private DataContext _dataContext;
        public RoutesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<RoutesClass>> GetAsync()
        {
            return await _dataContext.ListRoutes.Include(r=>r.Doctor).ToListAsync();
        }
        public async Task<RoutesClass> GetByIdAsync(int id)
        {
            var RoutesId = await _dataContext.ListRoutes.FirstOrDefaultAsync(x => x.IdRoutes == id);
            if (RoutesId == null)
                return null;
            return  RoutesId;
        }
        public async Task<RoutesClass> AddAsync(RoutesClass route)
        {

            var indexDoctor = _dataContext.ListDoctors.FirstOrDefault(x => x.Id == route.DoctorId);
            var indexPatient = _dataContext.ListPatient.FirstOrDefault(x => x.Id == route.PatientId);
            if ( indexPatient != null && indexDoctor != null)
            {
                _dataContext.ListRoutes.AddAsync(route);
                await _dataContext.SaveChangesAsync();
                return  route;
            }
            return null;
        }

        public async Task UpdateAsync(int id, RoutesClass route)
        {
            var Route = _dataContext.ListRoutes.FirstOrDefault(x => x.IdRoutes == id);
            var indexDoctor=_dataContext.ListDoctors.FirstOrDefault(x=>x.Id==route.DoctorId);
            var indexPatient = _dataContext.ListPatient.FirstOrDefault(x => x.Id == route.PatientId);

            if (Route != null && indexDoctor != null && indexPatient != null)
            {

                Route.Date = route.Date;
                Route.StartTime = route.StartTime;
                Route.EndTime = route.EndTime;
                Route.DoctorId = route.DoctorId;
                Route.PatientId = route.PatientId;
                await _dataContext.SaveChangesAsync();
                return;
            }
/*                return Ok("התור לא קיים או שה - id של הדוקטור אן של הלקוח לא קיים");
*/   
        }


     
        public async Task DeleteIdAsync(int id)
        {
            var routes=_dataContext.ListRoutes.FirstOrDefault(x => x.IdRoutes==id);
             _dataContext.ListRoutes.Remove(routes);
            await _dataContext.SaveChangesAsync();

        }

    }
}
