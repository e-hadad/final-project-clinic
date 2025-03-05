using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Entities
{
    public class PatientClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public double age {  get; set; }
        public List<RoutesClass> Routes { get; set; }
        //public int UserId { get; set; }
        public UserClass User { get; set; }

    }
}
