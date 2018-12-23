using TechnologyCharacterGenerator.Child.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnologyCharacterGenerator.Foundation.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public interface ITechnologyCharacterCreator
    {
        TechnologyCharacterViewModel GenerateTechnologyCharacter(UserViewModel userViewModel);
    }
}
