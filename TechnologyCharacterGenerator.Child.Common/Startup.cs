using TechnologyCharacterGenerator.Child.Common.BusinessLogic;
using TechnologyCharacterGenerator.Child.Common.Diagnostics;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace TechnologyCharacterGenerator.Child.Common
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

            services.AddScoped<ITechnologyCharacterCreator, BusinessLogic.TechnologyCharacterCreator>();

            services.AddScoped<ITechnologyCharacterPropertyGenerator, CharacterNameTechnologyCharacterPropertyGenerator>();
            services.AddScoped<ITechnologyCharacterPropertyGenerator, CharacterClassTechnologyCharacterPropertyGenerator>();

            services.AddScoped<ITechnologyCharacterPropertyGenerator, HitPointsTechnologyCharacterPropertyGenerator>();
            services.AddScoped<ITechnologyCharacterPropertyGenerator, StrengthTechnologyCharacterPropertyGenerator>();
            services.AddScoped<ITechnologyCharacterPropertyGenerator, AgilityTechnologyCharacterPropertyGenerator>();
            services.AddScoped<ITechnologyCharacterPropertyGenerator, IntelligenceTechnologyCharacterPropertyGenerator>();
            services.AddScoped<ITechnologyCharacterPropertyGenerator, CharismaTechnologyCharacterPropertyGenerator>();
            services.AddScoped<ITechnologyCharacterPropertyGenerator, WisdomTechnologyCharacterPropertyGenerator>();
            services.AddScoped<ITechnologyCharacterPropertyGenerator, LuckTechnologyCharacterPropertyGenerator>();
            services.AddScoped<ITechnologyCharacterPropertyGenerator, ConstitutionTechnologyCharacterPropertyGenerator>();
            services.AddScoped<ITechnologyCharacterPropertyGenerator, PerceptionTechnologyCharacterPropertyGenerator>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
