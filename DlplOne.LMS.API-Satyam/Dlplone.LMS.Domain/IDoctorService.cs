using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain
{
    public interface IDoctorService
    {
        Task<int> DoctorSignUp(DoctorInsert doctor);
        Task<IEnumerable<Doctor>> Doctors();
        Task<Doctor> Doctor(int id);
        Task<int> DeleteDoctor(int id);
    }
}
