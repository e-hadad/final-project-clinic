using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Repositories
{
    public interface IRoutesRepository
    {

        public Task<IEnumerable<RoutesClass>> GetAsync();
        public  Task<RoutesClass> GetByIdAsync(int id);
        public Task<RoutesClass> AddAsync(RoutesClass route);
        public  Task UpdateAsync(int id, RoutesClass routes);
        public  Task DeleteIdAsync(int id);
    }
}
