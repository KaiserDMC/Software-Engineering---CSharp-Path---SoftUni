using System;

namespace PT_HospitalApp.Models
{
    public class ExaminationRecord
    {
        public string PatientEmail { get; set; }
        public string Diagnosis { get; set; }
        public DateTime Date { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpeciality { get; set; }
    }
}
