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
    public class TableService : ITableService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RestaurantTable>> GetTables()
        {
            return await _unitOfWork.TableRepository.GetTables();
        }
    }
}
