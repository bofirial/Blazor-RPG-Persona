using TechnologyCharacterGenerator.Foundation.Models;
using TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public class LuckTechnologyCharacterPropertyGenerator : ITechnologyCharacterPropertyGenerator
    {
        public ushort UserHashIndex => 8;
        public ushort Order => 10;

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel TechnologyCharacterViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            TechnologyCharacterViewModel.Luck = userHashValue;
        }
    }
}