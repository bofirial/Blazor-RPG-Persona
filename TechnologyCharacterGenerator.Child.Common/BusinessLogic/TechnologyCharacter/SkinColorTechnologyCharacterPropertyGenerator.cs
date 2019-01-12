using System.Collections.Generic;
using TechnologyCharacterGenerator.Foundation.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public class SkinColorTechnologyCharacterPropertyGenerator : ITechnologyCharacterPropertyGenerator
    {
        public List<string> SkinColors = new List<string>()
        {
            "#FFDFC4",
            "#F0D5BE",
            "#E1B899",
            "#FFDCB2",
            "#E5C298",
            "#E5B887",
            "#E5A073",
            "#DB9065",
            "#CE967C",
            "#C67856",
            "#A57257",
            "#F0C8C9",
            "#AD6452",
            "#5C3836",
            "#704139",
            "#8D5524",
        };

        public ushort UserHashIndex => 16;

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel technologyCharacterViewModel,
            ushort userHashValue, UserViewModel userViewModel)
        {
            technologyCharacterViewModel.TechnologyCharacterAvatar.SkinColor = SkinColors[userHashValue];
        }
    }
}