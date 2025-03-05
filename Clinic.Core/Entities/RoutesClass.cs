using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Entities
{
    public class RoutesClass
    {
        [Key]
        public int IdRoutes { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PatientId {  get; set; }
        public int DoctorId {  get; set; }
        public DoctorClass Doctor { get; set; }
        public PatientClass Patient { get; set; }


    }
}
