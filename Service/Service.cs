using StudentAPI.BL.Interface;
using StudentAPI.BL.Operations;
using StudentAPI.Model;

namespace StudentAPI.Service
{
    public static class Service
    {
        public static void RegisterStudentService(this IServiceCollection services)
        {
            // Register the BLStudentHandler as a service
            services.AddScoped<IBLStudentHandler, BLStudentHandler>();
            // Register the Response class as a service
            services.AddScoped<Response>();
        }
    }
}
