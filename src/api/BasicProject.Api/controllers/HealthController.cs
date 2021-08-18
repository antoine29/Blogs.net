namespace BasicProject.Api.controllers
{
    using BasicProject.Logger;
    using BasicProject.Services;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Configuration;
    using System.Reflection;

    [ApiController]
    public class HealthController : BaseController
    {
        private readonly IHealthService healthService;
        private readonly Ilogger logger;

        public HealthController(IHealthService healthService, Ilogger logger) : base(logger)
        {
            this.healthService = healthService;
            this.logger = logger;
        }


        [HttpGet("[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Index()
        {
            return InvokeAndReturnResult(() =>
            {
                logger.Information("Calling to Index");

                var currentApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version;
                var name = ConfigurationManager.AppSettings["name"];

                var applicationHealthInfo = healthService.GetApplicationHealthInfo(name, currentApplicationVersion);

                return applicationHealthInfo;
            }, StatusCodes.Status200OK);   
        }
    }
}
