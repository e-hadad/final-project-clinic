using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Entities
{
    public class DoctorClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public int BusinessHours { get; set; }
        public List<RoutesClass> Routess { get; set; }
        //public int UserId { get; set; }
        public UserClass User { get; set; }
    }
}
