using Reservations.Backend.Models;
using Reservations.Backend.Shared.Interfaces.Data;
using Reservations.Backend.Shared.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.Backend.Service
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Reservation>> GetReservations(DateOnly date, int? shiftId, int? tableId)
        { 
            return  await _unitOfWork.ReservationRepository.GetReservations(date, shiftId, tableId);
        }
    }
}