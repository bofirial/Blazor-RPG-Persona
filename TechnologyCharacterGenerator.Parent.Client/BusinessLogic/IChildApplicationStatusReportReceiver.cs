using System;
using System.Collections.Generic;
using TechnologyCharacterGenerator.Models;

namespace TechnologyCharacterGenerator.Parent.Client.BusinessLogic
{
    public interface IChildApplicationStatusReportReceiver
    {
        List<ChildApplicationStatusReportModel> ChildApplicationStatusReports { get; }

        event Action<ChildApplicationStatusReportModel> ChildApplicationStatusReportReceived;

        ChildApplicationStatusReportModel ReceiveStatusReport(ChildApplicationStatusReportModel frameApplicationStatusReport);
    }
}