using Microsoft.EntityFrameworkCore;

namespace HospitalMngSys.Models
{
    public class HospitalMngSysDbContext : DbContext
    {
        public HospitalMngSysDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
