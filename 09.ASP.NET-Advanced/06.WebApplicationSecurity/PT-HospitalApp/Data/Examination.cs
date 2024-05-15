using System;
using Microsoft.AspNetCore.Identity;

namespace PT_HospitalApp.Data
{
    public class Examination
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public DateTime Date { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpeciality { get; set; }
        public string PatientId { get; set; }
        public IdentityUser Patient { get; set; }
    }
}
