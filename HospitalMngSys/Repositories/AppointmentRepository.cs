using HospitalMngSys.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalMngSys.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalMngSysDbContext _context;
        public AppointmentRepository(HospitalMngSysDbContext context)
        {
                _context = context;
        }
        public async Task<Appointment> Add(Appointment appmt)
        {
            await _context.Appointments.AddAsync(appmt);
            await _context.SaveChangesAsync();
            return appmt;
        }

        public async Task<Appointment?> Delete(int id)
        {
            var aptmt = await _context.Appointments.FindAsync(id);
            if (aptmt == null)
            {
                Console.WriteLine("Appointment Not Found");
                return null;
            }
            _context.Appointments.Remove(aptmt);
            await _context.SaveChangesAsync();
            return aptmt;
        }

        public async Task<List<Appointment>> GetAll()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment?> GetById(int id)
        {
            var appmt = await _context.Appointments.FindAsync(id);
            if (appmt == null)
            {
                return null;
            }
            return appmt;
        }

        public async Task<Appointment> Update(Appointment appmt)
        {
            var existingAptmt = await _context.Appointments.FindAsync(appmt.AppointmentId);
            if (existingAptmt == null)
            {
                return null;
            }
            existingAptmt.AppointmentId = appmt.AppointmentId;
            existingAptmt.Doctor_id = appmt.Doctor_id;
            existingAptmt.Concern = appmt.Concern;
            existingAptmt.Status = appmt.Status;
            existingAptmt.Appointment_date = appmt.Appointment_date;
            existingAptmt.Appointment_time = appmt.Appointment_time;
            existingAptmt.Updated_at = appmt.Updated_at;

            await _context.SaveChangesAsync();
            return existingAptmt;
        }
    }
}
