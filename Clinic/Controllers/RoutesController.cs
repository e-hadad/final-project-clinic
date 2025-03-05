using AutoMapper;
using clinic.Models;
using Clinic.Core.DTOs;
using Clinic.Core.Entities;
using Clinic.Core.Services;
using Clinic.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class RoutesController : ControllerBase
    {
        private readonly IRoutesService _routesService;
        private readonly IMapper _mapper;

        public RoutesController(IRoutesService routesService, IMapper mapper)
        {
            _routesService = routesService;
            _mapper = mapper;

        }
        // GET: api/<Routes>
        [HttpGet]
        public async Task<ActionResult<RoutesClass>> GetAsync()
        {
            var list = await _routesService.GetRoutesAsync();
            var Dtolist = new List<RouteDTO>();
            Dtolist = _mapper.Map<List<RouteDTO>>(list);
            return Ok(Dtolist);
        }
        // GET api/<Routes>/5
        [HttpGet("{id}")]
        public async Task<RoutesClass> GetAsync(int id)
        {
            return await _routesService.GetRouresByIdAsync(id);
        }
        // POST api/<Routes>
        [HttpPost]
        public async Task<RoutesClass> PostAsync([FromBody] RouteModel value)
        {
            /*   var newRoutes = new RoutesClass { Date = value.Date, StartTime = value.StartTime, EndTime = value.EndTime };
               await _routesService.AddRoutesAsync(newRoutes);
               return newRoutes;*/
            return await _routesService.AddRoutesAsync(_mapper.Map<RoutesClass>(value));

           /* return await _routesService.AddRoutesAsync(_mapper.Map<
                RoutesClass>(value));*/
        }
        // PUT api/<Routes>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] RouteModel value)
        {
            /* var newRoutes = new RoutesClass { Date = value.Date, StartTime = value.StartTime, EndTime = value.EndTime };
             await _routesService.UpdateRoutesAsync(id, newRoutes);*/
            await _routesService.UpdateRoutesAsync(id,_mapper.Map<RoutesClass>(value)); 

        }
        // DELETE api/<Routes>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
         /*   var index = _routesService.GetRoutes().ToList().FindIndex(e => e.IdRoutes== id);
            _routesService.GetRoutes().ToList().RemoveAt(index);*/
         await _routesService.DeleteRoutesAsync(id);
        }
    }
}
