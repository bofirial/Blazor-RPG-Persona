using TechnologyCharacterGenerator.Foundation.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public class AccentColorTechnologyCharacterPropertyGenerator : ITechnologyCharacterPropertyGenerator
    {
        public ushort UserHashIndex => 25;

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel technologyCharacterViewModel,
            ushort userHashValue, UserViewModel userViewModel)
        {
            technologyCharacterViewModel.TechnologyCharacterAvatar.AccentColor =
                $"#{technologyCharacterViewModel.UserHash.Substring(25, 6)}";
        }
    }
}