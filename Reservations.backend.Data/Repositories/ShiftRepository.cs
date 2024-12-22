using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservations.Backend.DataEntity.EFModels.Context;
using Reservations.Backend.Models;
using Reservations.Backend.Shared.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservations.backend.Data.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly DbDataContext _context;
        private readonly IMapper _mapper;
        public ShiftRepository(DbDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Shift>> GetShifts()
        {
            var shifts = await _context.rest_shift.ToListAsync();
            return _mapper.Map<List<Shift>>(shifts);
        }
    }
}
