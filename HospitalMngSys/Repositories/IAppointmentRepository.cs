using HospitalMngSys.Models;

namespace HospitalMngSys.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAll();
        Task<Appointment> Add(Appointment appmt);
        Task<Appointment?> GetById(int id);

        Task<Appointment> Update(Appointment appmt);

        Task<Appointment?> Delete(int id);
    }
}
