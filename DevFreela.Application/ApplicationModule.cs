using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Commands.InsertUser;
using DevFreela.Application.Models.ViewModel;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                //.AddServices()
                .AddHandlers();
            
            return services;
        }
        //private static IServiceCollection AddServices(this IServiceCollection services)
        //{
        //    services.AddScoped<IProjectService, ProjectService>();
        //    return services;
        //}
        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            /* Vai adicionar todos os serviços que estejam implementando IRequest e IResquestHandler
             * do assembly do projeto que contem InsertProjectCommand e esta na camada Application
             * ele vai buscar em todo o projeto application pelos os comandos
             */
             
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());

            services.AddTransient<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>, InsertProjectValidateCommandBehavior>();
            services.AddTransient<IPipelineBehavior<InsertUserCommand, ResultViewModel<int>>, InsertUserValidationCommand>();
            
            return services;
        }
    }
}
