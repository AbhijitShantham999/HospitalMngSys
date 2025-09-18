using HospitalMngSys.Models;

namespace HospitalMngSys.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment> AddAsync();
        Task<Appointment> GetByIdAsync(int id);

        Task<Appointment> UpdateAsync(int id);

        Task<Appointment> DeleteAsync(int id);
    }
}
