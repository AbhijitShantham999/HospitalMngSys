using HospitalMngSys.Models;

namespace HospitalMngSys.Repositories
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAll();
        Task<Patient> Add(Patient patient);
        Task<Patient?> GetById(int id);

        Task<Patient> Update(Patient patient);

        Task<Patient?> Delete(int id);
    }
}
