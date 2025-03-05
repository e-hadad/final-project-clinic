using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Entities
{
    public class UserClass
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public eRole Role { get; set; }
    }
    public enum eRole
    {
        doctor, patient
    }
}
