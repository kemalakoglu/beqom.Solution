using beqom.Application.CommandQuery;
using beqom.Application.Contract.Services;
using beqom.Domain.Contract.Interface;
using beqom.Domain.Repository;
using beqom.Domain.Repository.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace beqom.Presentation.API.Extensions
{
    public static class DependencyInjection
    {
        public static void ConfigureMediatr(this IServiceCollection services)
        {
            services.AddMediatR(typeof(OptionServiceHandler).GetTypeInfo().Assembly);
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOptionRepository, OptionRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
        }

        public static void ConfigureApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}