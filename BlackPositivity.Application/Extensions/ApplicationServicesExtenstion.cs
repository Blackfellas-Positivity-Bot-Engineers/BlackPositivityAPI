using BlackPositivity.Application.Abstractions;
using BlackPositivity.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackPositivity.Application.Extensions
{
    public static class ApplicationServicesExtenstion
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped
                <IBlackPositivityQuoteApplicationService,
                BlackPositivityQuoteApplicationService>();

            return services;
        }
    }
}
