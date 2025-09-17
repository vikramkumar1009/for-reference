using Dlplone.LMS.Domain.Infrastructure.Enums;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain.Infrastructure
{
    public class TemplateService : ITemplateService
    {
        private readonly IPartnerRepository repository;
        public TemplateService(IPartnerRepository _repository)
        {
           repository = _repository;
        }

        public async Task<Templates> GetTemplateAsync(int id)
        {
            try
            {
                var template = await repository.FindByIdAsync<Templates>(id,nameof(TABLES.TEMPLATES), nameof(SCHEMAS.DBO));
                return template;
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
