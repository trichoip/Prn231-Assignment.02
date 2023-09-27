using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EBookStore.Application;
public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper();
    }

    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

}
