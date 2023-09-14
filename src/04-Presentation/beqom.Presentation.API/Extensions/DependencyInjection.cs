using beqom.Application.Contract.Services;
using beqom.Application.Service;
using beqom.Application.UnitOfWork;
using beqom.Core.Contract;
using beqom.Domain.Aggregate.RefTypeValue;
using beqom.Domain.Context.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace beqom.Presentation.API.Extensions
{
    public static class DependencyInjection
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<CoreContext>(o => o.UseSqlServer(connectionString));

            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<Context>()
            //    .AddDefaultTokenProviders();
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureDomainService(this IServiceCollection services)
        {

            services.AddScoped<IOptionService, OptionService>();
        }

        public static void ConfigureApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ICoreApplicationService, ApplicationService>();
        }
    }
}