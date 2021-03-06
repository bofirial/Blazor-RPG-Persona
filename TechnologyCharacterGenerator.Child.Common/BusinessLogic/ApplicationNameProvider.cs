﻿using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using TechnologyCharacterGenerator.Foundation.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public class ApplicationNameProvider : IApplicationNameProvider
    {
        private readonly HttpClient httpClient;

        public ApplicationNameProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private static string ApplicationName { get; set; }

        public async Task<string> GetApplicationNameAsync()
        {
            if (string.IsNullOrEmpty(ApplicationName))
            {
                var application = await httpClient.GetJsonAsync<ChildApplicationModel>("application.json");

                ApplicationName = application.ApplicationName;
            }

            return ApplicationName;
        }
    }
}