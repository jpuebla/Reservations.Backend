using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.backend.Data.Mappings
{
    public static class MappingsExtension
    {
        public static void AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ReservationsMappings));
        }
       
    }
}
