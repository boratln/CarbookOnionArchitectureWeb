using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Services
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
        }
    }

}
