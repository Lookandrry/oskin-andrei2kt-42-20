using OskinAndreiKt_42_20.Interfaces;

namespace OskinAndreiKt_42_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPrepodService, PrepodService>();
            services.AddScoped<IDegreesService, DegreeService>();

            return services;
        }
    }
}
