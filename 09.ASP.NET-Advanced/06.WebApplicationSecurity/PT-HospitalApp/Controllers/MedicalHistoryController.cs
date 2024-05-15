using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PT_HospitalApp.Data;
using PT_HospitalApp.Models;
using System.Linq;
using System.Security.Claims;

namespace PT_HospitalApp.Controllers
{
    [Authorize]
    public class MedicalHistoryController : Controller
    {
        private HospitalDbContext data;
        public MedicalHistoryController(HospitalDbContext data)
            => this.data = data;

        public IActionResult Summary()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var records = this.data.Examinations
                .Where(ex => ex.PatientId == userId)
                .Select(ex => new MedicalRecord()
                {
                    Id = ex.Id,
                    Date = ex.Date,
                    DoctorName = ex.DoctorName
                })
                .ToList();

            return View(records);
        }

        public IActionResult Details(int examinationId)
        {
            var examination = this.data
                .Examinations
                .Include(ex => ex.Patient)
                .FirstOrDefault(ex => ex.Id == examinationId);
                
            if (examination == null)
            {
                return RedirectToAction("Summary");
            }

            var model = new ExaminationRecord()
            {
                Date = examination.Date,
                Diagnosis = examination.Diagnosis,
                DoctorName = examination.DoctorName,
                DoctorSpeciality = examination.DoctorSpeciality,
                PatientEmail = examination.Patient.Email
            };

            return View(model);
        }
    }
}
