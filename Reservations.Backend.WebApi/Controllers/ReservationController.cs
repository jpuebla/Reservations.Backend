using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservations.Backend.Models;
using Reservations.Backend.Shared.Interfaces.Services;

namespace Reservations.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("{date:datetime}/{shiftId:int?}/{tableId:int?}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations(DateTime date, int? shiftId, int? tableId)
        {
            return await _reservationService.GetReservations(DateOnly.FromDateTime(date), shiftId, tableId);
        }
    }
}
