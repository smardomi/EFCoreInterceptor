using EFCoreInterceptor.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCoreInterceptor.Data
{
    using System;
    using System.Reflection;
 
    public class ServiceInjectorInterceptor : IMaterializationInterceptor
    {
        private readonly IServiceProvider serviceProvider;

        public ServiceInjectorInterceptor(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public object InitializedInstance(MaterializationInterceptionData materializationData, object entity)
        {
            if (entity is IEntity)
            {
                var entityType = entity.GetType();
                var fields = entityType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                                          .Where(a=>a.FieldType.IsInterface);

                foreach (var field in fields)
                {
                    object? resolvedService = serviceProvider.GetService(field.FieldType);

                    if (resolvedService != null)
                    {
                        field.SetValue(entity, resolvedService);
                    }
                }
            }

            return entity;
        }
    }



}
