using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservations.Backend.DataEntity.EFModels;
using Reservations.Backend.DataEntity.EFModels.Context;
using Reservations.Backend.Models;
using Reservations.Backend.Shared.Interfaces.Data;
using Reservations.Backend.Shared.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.backend.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DbDataContext _context;
        private readonly IMapper _mapper;
        public ReservationRepository(DbDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Reservation>> GetReservations(DateOnly date, int? shiftId, int? tableId)
        {
            IQueryable<rest_reservation> query = _context.rest_reservation
                .Include(x => x.Shift)
                .Include(x => x.Table)
                .Where(x => x.Date == date);

            if (shiftId.HasValue)
            {
                query = query.Where(x => x.ShiftId == shiftId.Value);
            }

            if (tableId.HasValue)
            {
                query = query.Where(x => x.TableId == tableId.Value);
            }

            var reservations = await query.ToListAsync();
            return _mapper.Map<List<Reservation>>(reservations);
        }
        public async Task AddReservation(Reservation reservation)
        {
            var newReservation = _mapper.Map<rest_reservation>(reservation);
            await _context.rest_reservation.AddAsync(newReservation);       
        }
        public async Task UpdateReservation(Reservation reservation)
        {
            var updatedReservation = _mapper.Map<rest_reservation>(reservation);
            var reservationDb = await _context.rest_reservation.FirstOrDefaultAsync(x => x.Id == reservation.Id);
            _mapper.Map(updatedReservation, reservationDb);
        }
    }
}
