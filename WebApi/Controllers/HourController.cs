using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Logic.Contracts;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HourController : ApiBaseController
    {
        private readonly IHourLogic hourLogic;

        public HourController(ILogger<ApiBaseController> logger, IHourLogic hourLogic) : base (logger)
        {
            this.hourLogic = hourLogic;
        }

        [HttpGet("GetList/{campId}")]
        [Authorize(Roles = "Owner, Employee")]
        public IActionResult GetList(int campId)
        {
            try
            {
                return Ok(hourLogic.List(campId));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "GetList method");
                return NotFound(new { Message = "Ocurrió un error al listar los horarios" });
            }
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Owner, EmployeeHourCreate")]
        public IActionResult Create(HourForm form)
        {
            try
            {
                return Ok(hourLogic.Create(form.Time, form.DayOfWeek, form.IsEnabled, form.CampId));
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Create method");
                return NotFound(new { Message = "Ocurrió un error al intentar registrar el horario" });
            }
        }

        [HttpPost("ChangeState")]
        [Authorize(Roles = "Owner, EmployeeHourEdit")]
        public IActionResult ChangeState(HourForm form)
        {
            try
            {
                hourLogic.EnableDisable(form.Id, form.IsEnabled);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ChangeState method");
                return NotFound(new { Message = "Ocurrió un error" });
            }
        }
    }
}
