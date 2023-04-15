﻿using Carental.Domain.Repositories;
using Carental.Domain.UnitOfWork;
using Carental.Infrastructure.Persistence.Contexts;
using Carental.Infrastructure.Persistence.Repositories;
using Carental.Infrastructure.Persistence.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace Carental.Infrastructure.Persistence
{
    public static class Startup
    {
        public static void AddInfrastructurePersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DomainDB"));                
            });

            services.AddScoped<IRepositories, AppRepositories>();
            services.AddScoped<IUnitOfWork, AppUnitOfWork>();
        }
    }
}
