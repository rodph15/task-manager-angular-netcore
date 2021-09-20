using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.CrossCutting.Caching.CacheManager;
using TaskManager.CrossCutting.Configuration.Configurations;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infrastructure.Repositories;
using TaskManager.Service.Interfaces;
using TaskManager.Service.Services;

namespace TaskManager.CrossCutting.IoC.Extensions
{
    public static class ServiceDependecyExtensions
    {
        public static void AddServicesAndRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskRepository, TaskRepository>();
        }

        public static void AddCaching(this IServiceCollection services)
        {
            services.AddSingleton<ICacheManagerFactory, CacheManagerFactory>();
        }

        public static void AddMapperProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
