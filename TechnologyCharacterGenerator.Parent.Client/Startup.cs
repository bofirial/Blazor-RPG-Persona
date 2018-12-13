using Blazor.Extensions.Logging;
using TechnologyCharacterGenerator.Parent.Client;
using TechnologyCharacterGenerator.Parent.Client.BusinessLogic;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TechnologyCharacterGenerator.Parent.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
                builder.AddBrowserConsole()
                    .SetMinimumLevel(LogLevel.Information));

            services.AddSingleton<IChildApplicationStatusReportReceiver, ChildApplicationStatusReportReceiver>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
