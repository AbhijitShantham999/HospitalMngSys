using HospitalMngSys.Models;

namespace HospitalMngSys.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalMngSysDbContext _context;
        public AppointmentRepository(HospitalMngSysDbContext context)
        {
                _context = context;
        }
        public Task<Appointment> AddAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
