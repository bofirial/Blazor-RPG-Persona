using TechnologyCharacterGenerator.Foundation.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public class MainColorTechnologyCharacterPropertyGenerator : ITechnologyCharacterPropertyGenerator
    {
        public ushort UserHashIndex => 18;

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel technologyCharacterViewModel,
            ushort userHashValue, UserViewModel userViewModel)
        {
            technologyCharacterViewModel.TechnologyCharacterAvatar.MainColor =
                $"#{technologyCharacterViewModel.UserHash.Substring(18, 6)}";
        }
    }
}