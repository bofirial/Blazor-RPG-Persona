using TechnologyCharacterGenerator.Foundation.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public interface ITechnologyCharacterCreator
    {
        TechnologyCharacterViewModel GenerateTechnologyCharacter(UserViewModel userViewModel);
    }
}
