using Mapster;
using Dlplone.LMS.DTO.Infrastructure;
using System.Reflection;

namespace Dlplone.LMS.Infrastructure
{

    public static class MapsterConfiguration
    {
        public static void AddMapster(this IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            Assembly applicationAssembly = typeof(BaseDto<,>).Assembly;
            typeAdapterConfig.Scan(applicationAssembly);
        }
    }
}
