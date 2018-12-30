using TechnologyCharacterGenerator.Foundation.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public interface ITechnologyCharacterPropertyGenerator
    {
        ushort UserHashIndex { get; }

        void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel technologyCharacterViewModel, ushort userHashValue, UserViewModel userViewModel);
    }
}
