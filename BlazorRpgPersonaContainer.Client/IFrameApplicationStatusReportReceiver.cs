using System;
using System.Collections.Generic;

namespace BlazorRpgPersonaContainer.Client
{
    public interface IFrameApplicationStatusReportReceiver
    {
        List<FrameApplicationStatusReport> FrameApplicationStatusReports { get; }

        event Action<FrameApplicationStatusReport> FrameApplicationStatusReportReceived;

        void ReceiveStatusReport(FrameApplicationStatusReport frameApplicationStatusReport);
    }
}