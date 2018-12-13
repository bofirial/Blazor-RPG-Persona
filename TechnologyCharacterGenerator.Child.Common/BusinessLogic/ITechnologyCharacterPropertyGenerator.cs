using TechnologyCharacterGenerator.Models;
using TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public interface ITechnologyCharacterPropertyGenerator
    {
        ushort UserHashIndex { get; }

        ushort Order { get; }

        void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel TechnologyCharacterViewModel, ushort userHashValue, UserViewModel userViewModel);
    }
}
