using System;
using System.Collections.Generic;
using Microsoft.JSInterop;
using TechnologyCharacterGenerator.Foundation.Models;

namespace TechnologyCharacterGenerator.Parent.Client.BusinessLogic
{
    public class ChildApplicationStatusReportReceiver : IChildApplicationStatusReportReceiver
    {
        public List<ChildApplicationStatusReportModel> ChildApplicationStatusReports { get; set; } = new List<ChildApplicationStatusReportModel>();

        public event Action<ChildApplicationStatusReportModel> ChildApplicationStatusReportReceived;

        protected virtual void OnChildApplicationStatusReportReceived(
            ChildApplicationStatusReportModel childApplicationStatusReport)
        {
            ChildApplicationStatusReportReceived?.Invoke(childApplicationStatusReport);
        }

        [JSInvokable]
        public ChildApplicationStatusReportModel ReceiveStatusReport(ChildApplicationStatusReportModel childApplicationStatusReport)
        {
            childApplicationStatusReport.CreatedOn = DateTime.Now;

            ChildApplicationStatusReports.Add(childApplicationStatusReport);

            OnChildApplicationStatusReportReceived(childApplicationStatusReport);

            return childApplicationStatusReport;
        }
    }
}
