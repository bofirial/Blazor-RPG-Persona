using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public interface IApplicationNameProvider
    {
        Task<string> GetApplicationNameAsync();
    }
}
