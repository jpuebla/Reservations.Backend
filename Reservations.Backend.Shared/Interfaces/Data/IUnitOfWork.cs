using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Backend.Shared.Interfaces.Data
{
    public interface IUnitOfWork
    {
        IShiftRepository ShiftRepository { get; }
        ITableRepository TableRepository { get; }
        IReservationRepository ReservationRepository { get; }

        void ResetEntities();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
