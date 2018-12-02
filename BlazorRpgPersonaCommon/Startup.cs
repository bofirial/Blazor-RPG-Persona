using BlazorRpgPersonaCommon.BusinessLogic;
using BlazorRpgPersonaCommon.Diagnostics;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace BlazorRpgPersonaCommon
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);

                builder.Services.TryAddEnumerable(ServiceDescriptor
                    .Singleton<ILoggerProvider, BrowserConsoleLoggerProvider>());
            });

            services.AddScoped<IRpgPersonaGenerator, RpgPersonaGenerator>();

            services.AddScoped<IRpgPersonaPropertyGenerator, CharacterNameRpgPersonaPropertyGenerator>();
            services.AddScoped<IRpgPersonaPropertyGenerator, CharacterClassRpgPersonaPropertyGenerator>();

            services.AddScoped<IRpgPersonaPropertyGenerator, HitPointsRpgPersonaPropertyGenerator>();
            services.AddScoped<IRpgPersonaPropertyGenerator, StrengthRpgPersonaPropertyGenerator>();
            services.AddScoped<IRpgPersonaPropertyGenerator, AgilityRpgPersonaPropertyGenerator>();
            services.AddScoped<IRpgPersonaPropertyGenerator, IntelligenceRpgPersonaPropertyGenerator>();
            services.AddScoped<IRpgPersonaPropertyGenerator, CharismaRpgPersonaPropertyGenerator>();
            services.AddScoped<IRpgPersonaPropertyGenerator, WisdomRpgPersonaPropertyGenerator>();
            services.AddScoped<IRpgPersonaPropertyGenerator, LuckRpgPersonaPropertyGenerator>();
            services.AddScoped<IRpgPersonaPropertyGenerator, ConstitutionRpgPersonaPropertyGenerator>();
            services.AddScoped<IRpgPersonaPropertyGenerator, PerceptionRpgPersonaPropertyGenerator>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
