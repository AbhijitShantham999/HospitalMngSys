using HospitalMngSys.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalMngSys.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalMngSysDbContext _context;
        public DoctorRepository(HospitalMngSysDbContext context)
        {
           _context = context;
        }
        public async Task<Doctor> Add(Doctor doc)
        {
            await _context.Doctors.AddAsync(doc);
            await _context.SaveChangesAsync();
            return doc;
        }

        public async Task<Doctor?> Delete(int id)
        {
            var doc = await _context.Doctors.FindAsync(id);

            if (doc == null)
            {
                Console.WriteLine("Doctor Not Found");
                return null;
            }

            _context.Doctors.Remove(doc);
            await _context.SaveChangesAsync();
            return doc;

        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetById(int id)
        {
            var doc = await _context.Doctors.FindAsync(id);
            if (doc == null)
            {
                Console.WriteLine("Doctor Not Found");
            }
            return doc;
        }

        public async Task<Doctor> Update(Doctor doc)
        {
            var existingDoc = await _context.Doctors.FindAsync(doc.DoctorId);

            if (existingDoc == null)
            {
                Console.WriteLine("Doctor Not Found");
            }

            //await _context.Doctors.Update(existingDoc);

            existingDoc.Name = doc.Name;
            existingDoc.Specialization = doc.Specialization;
            existingDoc.Consultation_fee = doc.Consultation_fee;
            existingDoc.Phonenum = doc.Phonenum;
            existingDoc.Updated_at = doc.Updated_at;

            await _context.SaveChangesAsync();
            return existingDoc;

        }
    }
}
