using Reservations.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Backend.Shared.Interfaces.Services
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetReservations(DateOnly date, int? shiftId, int? tableId);
    }
}
