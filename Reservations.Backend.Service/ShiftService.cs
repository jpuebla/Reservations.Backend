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
    public class ShiftService : IShiftService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShiftService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Shift>> GetShifts()
        {
            return await _unitOfWork.ShiftRepository.GetShifts();
        }
        
    }
}
