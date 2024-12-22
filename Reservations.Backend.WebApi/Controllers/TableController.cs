using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservations.Backend.Models;
using Reservations.Backend.Service;
using Reservations.Backend.Shared.Interfaces.Services;

namespace Reservations.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantTable>>> GetTables()
        {
            return await _tableService.GetTables();
        }
    }
}