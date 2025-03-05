using AutoMapper;
using clinic.Models;
using Clinic.Core.DTOs;
using Clinic.Core.Entities;
using Clinic.Core.Services;
using Clinic.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    [Authorize(Roles = "doctor")]

    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public DoctorController(IDoctorService service,IMapper mapper,IUserService userService)
        {
            _service = service;
            _mapper = mapper;
            _userService = userService;
        }
        // GET: api/<Doctor>
        [HttpGet]
        public async Task<ActionResult<DoctorClass>> GetAsync()
        {

            var list = await _service.GetDoctorAsync();
            var Dtolist = new List<DoctorDTO>();
            Dtolist = _mapper.Map<List<DoctorDTO>>(list);

            return Ok(Dtolist);
        }

        // GET api/<Doctor>/5
        [HttpGet("{id}")]
        public async Task<DoctorClass> GetAsync(int id)
        {
            return await _service.GetDoctorByIdAsync(id);
        }

        // POST api/<Doctor>
        [HttpPost]
        public async  Task<ActionResult> PostAsync([FromBody] DoctorModel value)
        {
            /*   var newDoctor = new DoctorClass { Name = value.Name, Phone = value.Phone, Email = value.Email  };
               await _service.AddDoctorAsync(newDoctor);
               return newDoctor;*/
            var user1 = new UserClass { UserName = value.UserName, Password = value.Password, Role = eRole.doctor };
            var User2 = await _userService.AddUserAsync(user1);
            var newCastomer = _mapper.Map<DoctorClass>(value);
            newCastomer.User = User2;
            newCastomer.Id = User2.Id;
            var Castomer = await _service.GetDoctorByIdAsync(newCastomer.Id);
            if (Castomer != null)
            {
                return Conflict();
            }
            await _service.AddDoctorAsync(newCastomer);
            return Ok();

        }


        // PUT api/<Doctor>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] DoctorModel value)
        {
            var doctor = _mapper.Map<DoctorClass>(value);
              await _service.UpdateDoctorAsync(id,doctor);

            /*var newDoctor = new DoctorClass { Name = value.Name, Phone = value.Phone, Email = value.Email };
            await _service.UpdateDoctorAsync(id, newDoctor);*/
/*            await _service.UpdateDoctorAsync(id,_mapper.Map<DoctorClass>(value));
*/
        }


        // DELETE api/<Doctor>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
           /* var index = _service.GetDoctor().ToList().FindIndex(e => e.Id == id);
            _service.GetDoctor().ToList().RemoveAt(index);*/
           await _service.DeleteDoctorAsync(id);
        }
    }
}
