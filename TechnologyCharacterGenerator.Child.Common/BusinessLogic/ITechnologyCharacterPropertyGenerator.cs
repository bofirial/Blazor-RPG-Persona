using TechnologyCharacterGenerator.Foundation.Models;
using TechnologyCharacterGenerator.Child.Common.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public interface ITechnologyCharacterPropertyGenerator
    {
        ushort UserHashIndex { get; }

        ushort Order { get; }

        void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel technologyCharacterViewModel, ushort userHashValue, UserViewModel userViewModel);
    }
}
