using TechnologyCharacterGenerator.Foundation.Models;
using TechnologyCharacterGenerator.Child.Common.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public class CharismaTechnologyCharacterPropertyGenerator : ITechnologyCharacterPropertyGenerator
    {
        public ushort UserHashIndex => 6;
        public ushort Order => 10;

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel TechnologyCharacterViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            TechnologyCharacterViewModel.Charisma = userHashValue;
        }
    }
}