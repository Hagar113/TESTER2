using DataProvider.IProvider;
using DataProvider.Provider;

namespace TESTER.ServiceBinding
{
    public static class Binding
    { 
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {


            services.AddScoped<IStudentProvider, StudentProvider>();
            services.AddScoped<ISchoolProvider, SchoolProvider>();
            return services;

        }
    }
}
