using Microsoft.Extensions.DependencyInjection;

namespace NotificationApp.Api
{
    public static class DependencyInjectionExtensions
    {
        public static void AddApi(this IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddApplicationPart(typeof(DependencyInjectionExtensions).Assembly);
        }
    }
}
