using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRpgPersona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BlazorRpgPersonaContainer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerApplicationsController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ContainerApplicationsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public List<ContainerApplication> Get()
        {
            return new List<ContainerApplication>()
            {
                new ContainerApplication()
                {
                    ApplicationName = "Client",
                    ApplicationUrl = configuration.GetValue<string>("ClientApplicationUrl")
                },
                new ContainerApplication()
                {
                    ApplicationName = "Server",
                    ApplicationUrl = configuration.GetValue<string>("ServerApplicationUrl")
                }
            };
        }
    }
}
