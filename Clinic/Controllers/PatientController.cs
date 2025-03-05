using AutoMapper;
using clinic.Models;
using Clinic.Core.DTOs;
using Clinic.Core.Entities;
using Clinic.Core.Services;
using Clinic.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Authorize(Roles = "patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;


        public PatientController( IUserService userService, IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
            _userService = userService;

        }
        // GET: api/<patient>
        [HttpGet]
        public async Task<ActionResult<PatientClass>> GetAsync()
        {
            var list = await _patientService.GetPatientAsync();
            var Dtolist = new List<PatientDTO>();
            Dtolist = _mapper.Map<List<PatientDTO>>(list);
            return Ok(Dtolist);

        }

        // GET api/<patient>/5
        [HttpGet("{id}")]
        public async Task<PatientClass> GetAsync(int id)
        {
            return await _patientService.GetPatientByIdAsync(id);
        }

        // POST api/<patient>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PatientModel value)
        {


            var user = new UserClass { UserName = value.UserName, Password = value.Password, Role = eRole.patient };
            var User = await _userService.AddUserAsync(user);
            var newCastomer = _mapper.Map<PatientClass>(value);
            newCastomer.User = User;
            newCastomer.Id = User.Id;
            var Castomer = await _patientService.GetPatientByIdAsync(newCastomer.Id);
            if (Castomer != null)
            {
                return Conflict();
            }
            await _patientService.AddPtientAsync(newCastomer);
            return Ok();


            /* var newPatient=new PatientClass { Name = value.Name, Phone = value.Phone, Email = value.Email, Address = value.Address,age=value.age};
             await _patientService.AddPtientAsync(newPatient);
             return newPatient;*/


/*            return await _patientService.AddPtientAsync(_mapper.Map<PatientClass>(value));
*/
        }

        // PUT api/<patient>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] PatientModel value)
        {
            /*var newPatient = new PatientClass { Name = value.Name, Phone = value.Phone, Email = value.Email, Address = value.Address, age = value.age };
             await _patientService.UpdatePatientAsync(id, newPatient);*/
            await _patientService.UpdatePatientAsync(id, _mapper.Map<PatientClass>(value));
        }


        // DELETE api/<patient>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
           /* var index = _patientService.GetPatient().ToList().FindIndex(e => e.Id == id);
            _patientService.GetPatient().ToList().RemoveAt(index);*/
            await _patientService.DeletePatientAsync(id);
        }
    }
}
