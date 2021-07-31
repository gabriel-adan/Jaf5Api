using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using WebApi.Models;
using Logic.Contracts;

namespace WebApi.Controllers
{
    public class CampController : ApiBaseController
    {
        private readonly ICampLogic campLogic;

        public CampController(ILogger<ApiBaseController> logger, ICampLogic campLogic) : base (logger)
        {
            this.campLogic = campLogic;
        }

        [HttpPost("FindInBufferZone")]
        [Authorize(Roles = "Player")]
        public IActionResult FindInBufferZone(BufferForm form)
        {
            try
            {
                var camps = campLogic.ListByBufferZone(form.Longitude, form.Latitude, form.Radius);
                return Ok(camps);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "FindInBufferZone method");
                return NotFound(new { Message = "Ocurrió un error." });
            }
        }
    }
}
