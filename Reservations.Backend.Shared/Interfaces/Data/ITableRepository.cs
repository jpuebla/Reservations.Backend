using Reservations.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Backend.Shared.Interfaces.Data
{
    public interface ITableRepository
    {
        Task<List<RestaurantTable>> GetTables();
    }
}
