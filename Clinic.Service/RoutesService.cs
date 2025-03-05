using Clinic.Core.Services;
using Clinic.Core.Repositories;
using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Clinic.Service
{
    public class RoutesService: IRoutesService
    {
        private IRoutesRepository _repository;
        public RoutesService(IRoutesRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<RoutesClass>> GetRoutesAsync()
        {
            return  await _repository.GetAsync();
        }
        public async Task<RoutesClass> GetRouresByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<RoutesClass> AddRoutesAsync(RoutesClass routes)
        {
            return await _repository.AddAsync(routes);
        }

        
        public async Task UpdateRoutesAsync(int id, RoutesClass routes)
        {
            var UpRoutes = await _repository.GetAsync();
            var UpRoutesTemp = UpRoutes.FirstOrDefault(x => x.IdRoutes == id);

            if (UpRoutesTemp != null)
                await _repository.UpdateAsync(id, routes);
        }



        public async Task DeleteRoutesAsync(int id)
        {

            var DelRoutes =await  _repository.GetAsync();
            var DelRoutesTemp = DelRoutes.FirstOrDefault(x => x.IdRoutes == id);
            if (DelRoutesTemp != null)
            {
                await _repository.DeleteIdAsync(id);
            }

        }
    }
}
