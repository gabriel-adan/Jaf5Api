using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using WebApi.Models;
using Logic.Dtos;
using Logic.Contracts;

namespace WebApi.Controllers
{
    public class CampManagerController : ApiBaseController
    {
        private readonly ICampLogic campLogic;
        private readonly IList<string> AbcFieldNames;

        public CampManagerController(ILogger<ApiBaseController> logger, ICampLogic campLogic, IConfiguration configuration) :base(logger)
        {
            this.campLogic = campLogic;
            string fieldNames = configuration.GetValue<string>("AbcFieldNames");
            AbcFieldNames = fieldNames.Split(',');
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Owner")]
        public IActionResult Create(CreateCampForm form)
        {
            try
            {
                string email = User.Identity.Name;
                CampDto createdCampDto = campLogic.Create(email, form.Name, form.Street, form.Number, form.Longitude, form.Latitude, AbcFieldNames, form.FieldCount);
                return Ok(createdCampDto);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Create method");
                return NotFound(new { Message = "Ocurrió un error" });
            }
        }

        [HttpGet("Fields/{id}")]
        [Authorize(Roles = "Owner, Employee")]
        public IActionResult Fields(int id)
        {
            try
            {
                var fields = campLogic.GetFields(id);
                return Ok(fields);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Fields method");
                return NotFound(new { Message = "Ocurrió un error" });
            }
        }

        [HttpPost("FieldEdit")]
        [Authorize(Roles = "Owner, EmployeeFieldEdit")]
        public IActionResult FieldEdit(FieldForm form)
        {
            try
            {
                campLogic.EditFieldState(form.FieldId, form.CampId, form.IsEnabled);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "FieldEdit method");
                return NotFound(new { Message = "Ocurrió un error" });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Owner, Employee")]
        public IActionResult Get()
        {
            try
            {
                string userName = User.Identity.Name;
                var camps = campLogic.List(userName);
                return Ok(camps);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Get method");
                return NotFound(new { Message = "Ocurrió un error." });
            }
        }
    }
}