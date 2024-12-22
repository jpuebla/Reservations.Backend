using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Reservations.Backend.DataEntity.EFModels.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservations.Backend.Shared.Interfaces.Data;
using Reservations.backend.Data.Repositories;

namespace Reservations.backend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbDataContext _dbDataContext;
        private readonly IShiftRepository _shiftRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IReservationRepository _reservationRepository;

        public UnitOfWork(DbDataContext clientDataContext, IShiftRepository shiftRepository, ITableRepository tableRepository, IReservationRepository reservationRepository)            
        {
            _dbDataContext = clientDataContext;
            _shiftRepository = shiftRepository;
            _tableRepository = tableRepository;
            _reservationRepository = reservationRepository;
        }

        public IShiftRepository ShiftRepository => _shiftRepository;
        public ITableRepository TableRepository => _tableRepository;
        public IReservationRepository ReservationRepository => _reservationRepository;
        public void ResetEntities()
        {
            var entries = _dbDataContext.ChangeTracker.Entries().ToList();
            foreach (var entry in entries)
                entry.State = EntityState.Detached;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntries = _dbDataContext.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged);

            foreach (var entry in modifiedEntries)
            {
                foreach (PropertyEntry propName in entry.Properties)
                {
                    var current = propName.CurrentValue;
                    var original = propName.OriginalValue;                    
                }
            }

            int result = await _dbDataContext.SaveChangesAsync();
            return result;
        }

        public void Dispose()
        {
            _dbDataContext.Dispose();
        }
    }
}
