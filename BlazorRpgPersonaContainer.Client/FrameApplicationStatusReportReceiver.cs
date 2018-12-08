using System;
using System.Collections.Generic;
using Microsoft.JSInterop;

namespace BlazorRpgPersonaContainer.Client
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
        public void ReceiveStatusReport(FrameApplicationStatusReport frameApplicationStatusReport)
        {
            FrameApplicationStatusReports.Add(frameApplicationStatusReport);

            OnFrameApplicationStatusReportReceived(frameApplicationStatusReport);
        }
    }
}
