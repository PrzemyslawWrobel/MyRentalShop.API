using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRentalShop.API.Controllers
{
    /// <summary>
    /// Kontroler odp za obsługę Rezerwacji
    /// </summary>
    [Route("api/reservation")]
    [Authorize]
    [EnableCors("MyAllowAngularOrigins")]
    public class ReservationController : BaseController
    {
      
        /// <summary>
        /// Zwraca listę reserwacji
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorModel))]
        public async Task<ActionResult<string>> GetReservationsAsync()
        {
            return "Reservation Controller";
        }
    }
}
