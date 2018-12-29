using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using TechnologyCharacterGenerator.Foundation.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public class StatusReportSender : IStatusReportSender
    {
        private readonly IApplicationNameProvider applicationNameProvider;

        public StatusReportSender(IApplicationNameProvider applicationNameProvider)
        {
            this.applicationNameProvider = applicationNameProvider;
        }

        public async Task SendStatusReportAsync(ChildApplicationStatuses status)
        {
            var statusReport = new ChildApplicationStatusReport()
            {
                ApplicationName = await applicationNameProvider.GetApplicationNameAsync(),
                ChildApplicationStatus = status
            };

            await JSRuntime.Current.InvokeAsync<object>(
                "statusReportSender.send", statusReport);
        }
    }
}