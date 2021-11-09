using CharlaDDD.Application.Behaviors;
using CharlaDDD.Application.Commands;
using CharlaDDD.Application.Queries;
using CharlaDDD.Domain.Core;
using CharlaDDD.Domain.DomainServices;
using CharlaDDD.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CharlaDDD.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(IPizzaApplicationQueries), typeof(PizzaApplicationQueries));

            services.AddScoped(typeof(IPizzaApplicationMapper), typeof(PizzaApplicationMapper));

            services.AddScoped(typeof(PizzaOrderDomainService));

            return services;
        }

        public static IServiceCollection ConfigureDataBase(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PizzaApplicationDbContext>();

                context.Database.Migrate();

                context.SeedData();
            }

            return services;
        }

        public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreatePizzaOrderCommandHandler).Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            return services;
        }
    }
}
