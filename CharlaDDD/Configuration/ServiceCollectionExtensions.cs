using CharlaDDD.Application.Behaviors;
using CharlaDDD.Application.Commands;
using CharlaDDD.Application.Queries;
using CharlaDDD.Domain.Core;
using CharlaDDD.Domain.DomainServices;
using CharlaDDD.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CharlaDDD.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(IPizzaOrdersQueries), typeof(PizzaOrdersQueries));

            services.AddScoped(typeof(IPizzaOrderMapper), typeof(PizzaOrderMapper));

            services.AddScoped(typeof(PizzaOrderDomainService));

            services.AddMediatR(typeof(CreatePizzaOrderCommandHandler).Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            return services;
        }
    }
}
