using FSISSystem.BAL;
using FSISSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FSISSystem
{
    public static class FSISExtension
    {
        public static void AddBackendDependencies(this IServiceCollection services,
                  Action<DbContextOptionsBuilder> options)
        {
            //register the DbContext class in Chinook with the service collection
            services.AddDbContext<FSIS_2018Context>(options);

            //register service classes

            services.AddTransient<TeamService>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<FSIS_2018Context>();
                //create an instance of the service and return the instance
                return new TeamService(context);
            });
            services.AddTransient<GameService>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<FSIS_2018Context>();
                //create an instance of the service and return the instance
                return new GameService(context);
            });


        }
    }
}