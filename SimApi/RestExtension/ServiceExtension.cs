using SimApi.Operation;
using SimApi.Operation.TransactionReports;
using SimApi.Service.CustomService;

namespace SimApi.Service.RestExtension;

public static class ServiceExtension
{
    public static void AddServiceExtension(this IServiceCollection services)
    {      
        services.AddScoped<ScopedService>();
        services.AddTransient<TransientService>();
        services.AddSingleton<SingletonService>();
    }
}
