using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplayMappingFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplayMappingFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => typeof(IMap).IsAssignableFrom(t) && !t.IsInterface)
                .ToList();

            foreach(var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var method = type.GetMethod("Mapping");
                method?.Invoke(instance, new object[] { this });
            }
        }
    }
}
