using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnologyCharacterGenerator.Foundation.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public interface IStatusReportSender
    {
        Task SendStatusReportAsync(ChildApplicationStatuses status);
    }
}
