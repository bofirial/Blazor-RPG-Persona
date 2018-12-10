using System;
using System.Collections.Generic;
using BlazorRpgPersonaContainer.Client.Models;
using Microsoft.JSInterop;

namespace BlazorRpgPersonaContainer.Client.BusinessLogic
{
    public class FrameApplicationStatusReportReceiver : IFrameApplicationStatusReportReceiver
    {
        public List<FrameApplicationStatusReport> FrameApplicationStatusReports { get; set; } = new List<FrameApplicationStatusReport>();

        public event Action<FrameApplicationStatusReport> FrameApplicationStatusReportReceived;

        protected virtual void OnFrameApplicationStatusReportReceived(
            FrameApplicationStatusReport frameApplicationStatusReport)
        {
            FrameApplicationStatusReportReceived?.Invoke(frameApplicationStatusReport);
        }

        [JSInvokable]
        public FrameApplicationStatusReport ReceiveStatusReport(FrameApplicationStatusReport frameApplicationStatusReport)
        {
            frameApplicationStatusReport.CreatedOn = DateTime.Now;

            FrameApplicationStatusReports.Add(frameApplicationStatusReport);

            OnFrameApplicationStatusReportReceived(frameApplicationStatusReport);

            return frameApplicationStatusReport;
        }
    }
}
