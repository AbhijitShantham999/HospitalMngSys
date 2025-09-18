using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HospitalMngSys.Models
{
    public class Patient
    {
        //[Key]
        public int PatientId { get; set; } //Primary Key Combination( Patient + Id )

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string Phonenum { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; } = DateTime.Now;

        //Relationship with Appointments
        [ValidateNever]
        public ICollection<Appointment> Appointments { get; set; }//Collection Navigation Property
    }
}
