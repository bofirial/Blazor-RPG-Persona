using System;
using System.Collections.Generic;
using Microsoft.JSInterop;
using TechnologyCharacterGenerator.Foundation.Models;

namespace TechnologyCharacterGenerator.Parent.Client.BusinessLogic
{
    public class ChildApplicationStatusReportReceiver : IChildApplicationStatusReportReceiver
    {
        public event Action<ChildApplicationStatusReport> ChildApplicationStatusReportReceived;
        
        [JSInvokable]
        public void ReceiveStatusReport(ChildApplicationStatusReport childApplicationStatusReport)
        {
            ChildApplicationStatusReportReceived?.Invoke(childApplicationStatusReport);
        }
    }
}
