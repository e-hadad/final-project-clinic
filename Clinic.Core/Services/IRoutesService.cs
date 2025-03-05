using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Services
{
    public interface IRoutesService
    {
        public Task<IEnumerable<RoutesClass>> GetRoutesAsync();
        public Task<RoutesClass> GetRouresByIdAsync(int id);
        public Task<RoutesClass> AddRoutesAsync(RoutesClass routes);
        public Task UpdateRoutesAsync(int id, RoutesClass routes);
        public Task DeleteRoutesAsync(int id);
    }
}
