using Reservations.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Backend.Shared.Interfaces.Data
{
    public interface IShiftRepository
    {
        Task<List<Shift>> GetShifts();
    }
}
