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
    /// Kontroler odp za obsługę zadań
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyAllowAngularOrigins")]
    public class TaskController : Controller
    {
        /// <summary>
        /// Zwraca listę zadań
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorModel))]
        public async Task<ActionResult<string>> GetTasksAsync()
        {
            return "Task Controller";
        }
    }
}
