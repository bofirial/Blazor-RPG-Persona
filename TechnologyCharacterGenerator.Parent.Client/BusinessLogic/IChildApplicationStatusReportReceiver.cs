using System;
using System.Collections.Generic;
using TechnologyCharacterGenerator.Foundation.Models;

namespace TechnologyCharacterGenerator.Parent.Client.BusinessLogic
{
    public interface IChildApplicationStatusReportReceiver
    {
        event Action<ChildApplicationStatusReport> ChildApplicationStatusReportReceived;

        void ReceiveStatusReport(ChildApplicationStatusReport childApplicationStatusReport);
    }
}