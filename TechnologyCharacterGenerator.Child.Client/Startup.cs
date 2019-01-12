using System;
using System.IO;
using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using TechnologyCharacterGenerator.Avatar;
using TechnologyCharacterGenerator.Child.Common;
using TechnologyCharacterGenerator.Foundation.Models;

namespace TechnologyCharacterGenerator.Child.Client
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
                });
            });

            services.AddScoped<ITechnologyCharacterAvatarImageGenerator, TechnologyCharacterAvatarImageGenerator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/_framework/blazor.js")
                {
                    context.Request.Path = "/_framework/blazor.webassembly.js";
                }

                await next.Invoke();
            });

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/application.json")
                {
                    var application = new ChildApplicationModel()
                    {
                        ApplicationName = "Client",
                        ApplicationUrl = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}"
                    };

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(application));
                    return;
                }

                await next.Invoke();
            });

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/avatar.png", StringComparison.OrdinalIgnoreCase) && context.Request.Method == "POST")
                {
                    TechnologyCharacterAvatarModel model = null;
                    var technologyCharacterAvatarImageGenerator = context.RequestServices.GetService<ITechnologyCharacterAvatarImageGenerator>();

                    if (context.Request.Body != default(Stream) && context.Request.Body != Stream.Null)
                    {
                        var body = await new StreamReader(context.Request.Body).ReadToEndAsync();

                        model = JsonConvert.DeserializeObject<TechnologyCharacterAvatarModel>(body);
                    }

                    var avatar = technologyCharacterAvatarImageGenerator
                        .GenerateTechnologyCharacterAvatarImage(model);

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(avatar));

                    return;
                }

                await next.Invoke();
            });

            app.UseBlazor<TechnologyCharacterGenerator.Child.Common.Startup>();
        }
    }
}
