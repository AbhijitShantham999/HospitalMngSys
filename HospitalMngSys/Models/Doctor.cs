using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HospitalMngSys.Models
{
    public class Doctor
    {
        //[Key]

        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set;}

        [Required(ErrorMessage = "Specialization is Required")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "Fee is Required")]
        public int Consultation_fee { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string Phonenum { get; set; }

        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; } = DateTime.Now;

        //Relationship with Appointments
        [ValidateNever]
        public ICollection<Appointment> Appointments { get; set; } //Collection Navigation Property
    }
}
