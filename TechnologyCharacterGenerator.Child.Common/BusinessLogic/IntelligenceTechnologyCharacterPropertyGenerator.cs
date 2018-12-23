using TechnologyCharacterGenerator.Foundation.Models;
using TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public class IntelligenceTechnologyCharacterPropertyGenerator : ITechnologyCharacterPropertyGenerator
    {
        public ushort UserHashIndex => 5;
        public ushort Order => 10;

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel TechnologyCharacterViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            TechnologyCharacterViewModel.Intelligence = userHashValue;
        }
    }
}