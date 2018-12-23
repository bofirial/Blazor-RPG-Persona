using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnologyCharacterGenerator.Foundation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TechnologyCharacterGenerator.Parent.Server.Controllers
{
    [Route("api/child-applications")]
    [ApiController]
    public class ChildApplicationsController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ChildApplicationsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public List<ChildApplicationModel> Get()
        {
            return new List<ChildApplicationModel>()
            {
                new ChildApplicationModel()
                {
                    ApplicationName = "Client",
                    ApplicationUrl = configuration.GetValue<string>("ClientApplicationUrl")
                },
                new ChildApplicationModel()
                {
                    ApplicationName = "Server",
                    ApplicationUrl = configuration.GetValue<string>("ServerApplicationUrl")
                }
            };
        }
    }
}
