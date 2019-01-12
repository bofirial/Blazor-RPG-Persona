using System.Collections.Generic;
using TechnologyCharacterGenerator.Foundation.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public class HairColorTechnologyCharacterPropertyGenerator : ITechnologyCharacterPropertyGenerator
    {
        public List<string> HairColors = new List<string>()
        {
            "#090806",
            "#71635A",
            "#B7A69E",
            "#CABFB1",
            "#FFF5E1",
            "#E6CEA8",
            "#E5C8A8",
            "#DEBC99",
            "#B89778",
            "#A56B46",
            "#B55239",
            "#8D4A43",
            "#91553D",
            "#3B3024",
            "#6A4E42",
            "#977961",
        };

        public ushort UserHashIndex => 17;

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel technologyCharacterViewModel,
            ushort userHashValue, UserViewModel userViewModel)
        {
            technologyCharacterViewModel.TechnologyCharacterAvatar.HairColor = HairColors[userHashValue];
        }
    }
}