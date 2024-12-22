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
    public class TableRepository : ITableRepository
    {
        private readonly DbDataContext _context;
        private readonly IMapper _mapper;
        public TableRepository(DbDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<RestaurantTable>> GetTables()
        {
            var tables = await _context.rest_table.ToListAsync();
            return _mapper.Map<List<RestaurantTable>>(tables);
        }
    }
}
