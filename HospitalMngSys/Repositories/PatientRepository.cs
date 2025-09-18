using HospitalMngSys.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalMngSys.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalMngSysDbContext _context;
        public PatientRepository(HospitalMngSysDbContext context)
        {
            _context = context;
        }
        public async Task<Patient> Add(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient?> Delete(int id)
        {
            var existingId = await _context.Patients.FindAsync(id);
            if (existingId == null) { return null; }

            _context.Patients.Remove(existingId);
            await _context.SaveChangesAsync();
            return existingId;
        }

        public async Task<List<Patient>> GetAll()
        {
           return await _context.Patients.ToListAsync();
        }

        public async Task<Patient?> GetById(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(i => i.PatientId == id);
            //return patient;
        }

        public async Task<Patient> Update(Patient patient)
        {
            var existingUser = await _context.Patients.FindAsync(patient.PatientId);

            if (existingUser == null)
            {
                throw new Exception("Patient Not Found");
            }

            existingUser.Name = patient.Name;
            existingUser.Age = patient.Age;
            existingUser.Gender = patient.Gender;
            existingUser.Phonenum = patient.Phonenum;
            existingUser.Address = patient.Address;
            existingUser.Updated_at = patient.Updated_at;

            await _context.SaveChangesAsync();
            return existingUser;

        }
    }
}
