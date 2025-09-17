using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Dlplone.LMS.Domain
{
    public static class RepoConfig
    {
        public static void AddSqlServerRepositorySingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, string connectionStringName = "Default")
           where TService : class
          where TImplementation : class, TService
        {
 
            if (string.IsNullOrEmpty(connectionStringName) || connectionStringName == "Default")
                services.AddSingleton<TService, TImplementation>();
            else
                services.AddSingleton<TService>(x => GetObject<TImplementation>(services.BuildServiceProvider().GetService<IConfiguration>(), connectionStringName));
        }

        public static void AddSqlServerRepositoryTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, string connectionStringName = "Default")
                 where TService : class
                where TImplementation : class, TService
        {
            if (string.IsNullOrEmpty(connectionStringName) || connectionStringName == "Default")
                services.AddTransient<TService, TImplementation>();
            else
                services.AddTransient<TService>(x => GetObject<TImplementation>(services.BuildServiceProvider().GetService<IConfiguration>(), connectionStringName));
        }

        public static void AddSqlServerRepositoryScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, string connectionStringName = "Default")
           where TService : class
          where TImplementation : class, TService
        {
            if (string.IsNullOrEmpty(connectionStringName) || connectionStringName == "Default")
                services.AddScoped<TService, TImplementation>();
            else
                services.AddScoped<TService>(x => GetObject<TImplementation>(services.BuildServiceProvider().GetService<IConfiguration>(), connectionStringName));
        }

        private static T GetObject<T>(params object[] lstArgument)
        {
            return (T)Activator.CreateInstance(typeof(T), lstArgument);
        }
    }
}
