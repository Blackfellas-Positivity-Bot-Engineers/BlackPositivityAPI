using BlackPositivity.Infrastructure.DataAccess;
using BlackPositivity.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BlackPositivity.Infrastructure.Extensions
{
    public static class IntegrationServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped
                <IBlackPositivityQuotesRepository,
                BlackPositivityQuotesRepository>();

            return services;
        }
    }
}
