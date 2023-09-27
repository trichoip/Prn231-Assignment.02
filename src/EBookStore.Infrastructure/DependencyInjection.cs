using EBookStore.Application.Repositories;
using EBookStore.Infrastructure.Data;
using EBookStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EBookStore.Infrastructure;
public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddRepositories();
        services.AddServices();
    }

    public static void AddServices(this IServiceCollection services)
    {
        //services
        //    .AddTransient<IMediator, Mediator>()
        //    .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
        //    .AddTransient<IDateTimeService, DateTimeService>()
        //    .AddTransient<IEmailService, EmailService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
            .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //.AddTransient<IPlayerRepository, PlayerRepository>()
        //.AddTransient<IClubRepository, ClubRepository>()
        //.AddTransient<IStadiumRepository, StadiumRepository>()
        //.AddTransient<ICountryRepository, CountryRepository>();
    }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {

        var databseProvider = configuration["DatabaseProvider"];
        if (databseProvider == "Mysql")
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseMySQL(connectionString!,
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("Prn231As03DB"));
        }

    }

}
