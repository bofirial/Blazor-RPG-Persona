using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnologyCharacterGenerator.Foundation.Models
{
    public class ChildApplicationStatusReport
    {
        public string ApplicationName { get; set; }

        public ChildApplicationStatuses ChildApplicationStatus { get; set; }
    }
}
