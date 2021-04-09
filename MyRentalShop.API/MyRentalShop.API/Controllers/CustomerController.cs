using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRentalShop.API.Controllers
{
    /// <summary>
    /// Kontroler odp za obsługę użytkowników
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyAllowAngularOrigins")]

    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Zwraca listę użytkowników
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorModel))]
        public async Task<ActionResult<string>> GetCustomersAsync()
        {
            return "Customer Controller";
        }
    }
}

