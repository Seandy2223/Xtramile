using Microsoft.Extensions.DependencyInjection;
using Xtramile.Base.Interface;

namespace Xtramile.Base
{
    public static class RegisterFramework
    {
        public static void RegisterDI(this IServiceCollection services)
        {

            services.AddSingleton(typeof(IFeature), typeof(Feature));
            services.AddTransient<IRequestService, RequestService>();
        }
    }
}
