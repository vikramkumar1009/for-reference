using Microsoft.Extensions.Logging;
using Dlplone.LMS.Domain.Infrastructure.Enums;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IPartnerRepository repository;
        private readonly ICryptography cryptography;
        private readonly ILogger<DoctorService> logger;
        public DoctorService(IPartnerRepository _repository, ICryptography _cryptography,
                ILogger<DoctorService> _logger)
        {
            repository = _repository;
            cryptography = _cryptography;
            logger = _logger;
        }

        public async Task<int> DoctorSignUp(DoctorInsert doctor)
        {
            try
            {
                doctor.VEnterPassword = cryptography.Encrypt(doctor.VEnterPassword);
                var res = await repository.ExecuteRawSqlAsync<int, DoctorInsert>(nameof(PROCS.UDSP_PARTNER_SIGNUP), doctor, false);
                return res.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Doctor>> Doctors()
        {
            try
            {
                var res = await repository.ExecuteRawSqlAsync<Doctor, int?>(nameof(PROCS.UDSP_PARTNER_SIGNUP_RECORDS), null, false);
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> DeleteDoctor(int id)
        {
            try
            {
                await repository.ExecuteRawSqlAsync<int, object>(nameof(PROCS.UDSP_PARTNER_SIGNUP_DELETE), new { varid = id }, false);
                return 1;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Doctor> Doctor(int id)
        {
            try
            {
                var doctor = await repository.FindByIdAsync<Doctor>(id, nameof(TABLES.TBL_LPL_PARTNER_SIGNUP), nameof(SCHEMAS.DBO), "SId");
                return doctor;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
