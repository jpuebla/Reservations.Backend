using Reservations.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Backend.Shared.Interfaces.Data
{
    public interface IReservationRepository
    {
        Task AddReservation(Reservation reservation);
        Task<List<Reservation>> GetReservations(DateOnly date, int? shiftId, int? tableId);
        Task UpdateReservation(Reservation reservation);
    }
}
