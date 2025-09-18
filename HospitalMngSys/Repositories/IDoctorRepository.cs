using HospitalMngSys.Models;

namespace HospitalMngSys.Repositories
{
    public interface IDoctorRepository
    {
         Task<List<Doctor>> GetAll();
         Task<Doctor> Add(Doctor doc);
         Task<Doctor?> GetById(int id);

         Task<Doctor> Update(Doctor doc);

         Task<Doctor?> Delete(int id);
    }
}
