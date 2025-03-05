using Clinic.Core.Entities;

namespace clinic.Models
{
    public class RouteModel
    {
        public DateTime Date{ get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
