﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Dogs.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}