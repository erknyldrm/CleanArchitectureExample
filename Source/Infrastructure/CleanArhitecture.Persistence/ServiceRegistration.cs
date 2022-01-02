using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArhitecture.Persistence.Contexts;
using CleanArhitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArhitecture.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            //{
            //    serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseInMemoryDatabase("ApplicationDb"));
            //}
            //else
            //{
            //    serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            //   options.UseSqlServer(
            //       configuration.GetConnectionString("DefaultConnection"),
            //       b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            //}
            serviceCollection.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            serviceCollection.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
        }
    }
}
