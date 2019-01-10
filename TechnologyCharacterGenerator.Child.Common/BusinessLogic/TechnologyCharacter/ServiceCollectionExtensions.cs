using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public static class ServiceCollectionExtensions
    {
        public static List<(string displayText, ushort requiredThreshold)> Traits = new List<(string displayText, ushort requiredThreshold)>()
        {
            ("Proficient with SQL", 12),
            ("Proficient with Javascript", 12),
            ("Proficient with CSS", 12),
            ("Proficient with XML", 12),
            ("Proficient with JSON", 12),
            ("Proficient with Assembly", 12),

            ("REST API Expert", 14),
            ("SOAP Expert", 14),
            ("HTTP Specification Expert", 14),
            ("Debugging Expert", 14),

            ("Open Source Contributer", 10),
            ("Open Source Project Maintainer", 12),

            ("Technical Blogger", 12),
            ("Technical Podcaster", 12),
            ("Technical Conference Speaker", 13),
            ("Keynote Speaker", 15),

            //Affinity for Windows
            //Affinity for Mac
            //Affinity for Linux

            ("Passionate about AGILE", 13),
            ("Passionate about Scrum", 13),
            ("Passionate about DevOps", 13),
            ("Passionate about Documentation", 13),
            ("Passionate about Automation", 13),
            ("Passionate about Continuous Development", 13),
            ("Passionate about Continuous Delivery", 13),
            ("Passionate about Automated Testing", 13),
            ("Passionate about Unit Testing", 13),
            ("Passionate about Writing User Stories", 13),
            ("Passionate about Retrospectives", 13),
            ("Passionate about Post-Mortems", 13),
            ("Passionate about SOLID Principles", 13),
            ("Passionate about Design Documents", 13),
            ("Passionate about Design Reviews", 13),
            ("Passionate about Code Reviews", 13),
        };

        public static IServiceCollection AddTechnologyCharacterPropertyGenerators(this IServiceCollection services)
        {
            services.AddScoped<ITechnologyCharacterPropertyGenerator, CharacterNameTechnologyCharacterPropertyGenerator>();
            services.AddScoped<ITechnologyCharacterPropertyGenerator, CharacterClassTechnologyCharacterPropertyGenerator>();

            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(2, t => t.HitPoints, h => (ushort)(h * 50)));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(3, t => t.Strength, h => (ushort)(h / 2)));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(4, t => t.Agility, h => (ushort)(h / 2)));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(5, t => t.Intelligence, h => h));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(6, t => t.Programming, h => h));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(7, t => t.Documentation, h => h));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(8, t => t.Testing, h => h));
            services.AddScoped<ITechnologyCharacterPropertyGenerator>(sp =>
                new TechnologyCharacterPropertyGenerator<ushort>(9, t => t.Management, h => h));

            //10-15 Available

            //16 - Skin Color
            //17 - Hair Color
            //18 - Color 1 Contrast
            //19-24 Color 1 Hue
            //25 - Color 2 Contrast
            //16-31 Color 2 Hue

            ushort i = 32;
            foreach (var trait in Traits)
            {
                services.AddScoped<ITechnologyCharacterPropertyGenerator>(s =>
                    new TechnologyCharacterTraitGenerator(i++, trait.requiredThreshold, trait.displayText));
            }

            return services;
        }
    }
}
