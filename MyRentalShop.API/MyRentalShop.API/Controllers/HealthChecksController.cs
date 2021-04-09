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
    /// Służy do spr czy api działa
    /// </summary>
    [Route("api/hc")]
    [ApiController]
    //[EnableCors("MyAllowSpecificOrigins")]
    public class HealthChecksController : ControllerBase
    {
        /// <summary>
        /// Test
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorModel))]
        public async Task<ActionResult<string>> GetAsync()
        {
            return "Healthy";
        }
    }
}
