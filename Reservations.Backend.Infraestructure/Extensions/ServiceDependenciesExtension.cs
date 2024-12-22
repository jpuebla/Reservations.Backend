using Microsoft.Extensions.DependencyInjection;
using Reservations.backend.Data;
using Reservations.backend.Data.Repositories;
using Reservations.Backend.Service;
using Reservations.Backend.Shared.Interfaces.Data;
using Reservations.Backend.Shared.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Backend.Infraestructure.Extensions
{
    public static class ServiceDependenciesExtension
    {
        public static void AddServiceCollections(this IServiceCollection services)
        {            
            services.AddTransient<IShiftRepository, ShiftRepository>();
            services.AddTransient<ITableRepository, TableRepository>();

            services.AddTransient<IShiftService, ShiftService>();
            services.AddTransient<ITableService, TableService>();

            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IReservationRepository, ReservationRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
        }
    }
}
