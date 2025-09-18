using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalMngSys.Models
{
    public class Appointment
    {
        //[Key]
        public int AppointmentId { get; set; }

        [ForeignKey("Patient")]
        public int Patient_id { get; set; } //Foreign Key
        public Patient Patient { get; set; }// Reference Navigation Property


        [ForeignKey("Doctor")]
        public int Doctor_id { get; set; }//Foreign Key
        public Doctor Doctor { get; set; }// Reference Navigation Property

        public string Concern { get; set; }
        public string Status { get; set; }
        public DateOnly Appointment_date{get; set;}

        public TimeOnly Appointment_time { get; set; }

        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get;set; }

    }
}
