using System;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AccountManagerController : ApiBaseController
    {
        private readonly IConfiguration Configuration;

        public AccountManagerController(ILogger<ApiBaseController> logger, IConfiguration configuration) : base(logger)
        {
            Configuration = configuration;
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn(UserForm userForm)
        {
            try
            {
                string baseAuthUrl = Configuration.GetSection("Authority").Value;
                string applicationName = Configuration.GetSection("AppConfig:Name").Value;
                string domainName = Configuration.GetSection("Audience").Value;
                string authField = Configuration.GetSection("AuthenticationField").Value;
                string authUri = Configuration.GetSection("AuthUri").Value;

                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseAuthUrl);
                var obj = new
                {
                    UserName = userForm.UserName,
                    Password = userForm.Password,
                    ApplicationName = applicationName,
                    DomainName = domainName,
                    AuthenticationField = authField
                };
                string json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await httpClient.PostAsync(authUri, content);
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    LogInResult logInResult = await result.Content.ReadAsAsync(typeof(LogInResult)) as LogInResult;
                    return Ok(logInResult);
                }
                
                return NotFound(new { Message = "Usuario o contraseña inválido" });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "LogIn method");
                return BadRequest("Ocurrió un error");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            string appName = Configuration.GetSection("AppConfig:Name").Value;
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string response = string.Format("{0} Versión {1}", appName, version);
            return Ok(response);
        }
    }
}
