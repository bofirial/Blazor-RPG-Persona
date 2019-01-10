using System.Collections.Generic;
using System.Linq;
using TechnologyCharacterGenerator.Foundation.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public class CharacterNameTechnologyCharacterPropertyGenerator : ITechnologyCharacterPropertyGenerator
    {
        private readonly string[] _characterNameSuffixes = new[]
        {
            "Wise",
            "Rockstar",
            "Technology Master",
            "Destroyer of Defects",
            "Performance Expert",
            "Writer of Tickets",
            "Master of Change Control",
            "Always Up-to-Date",
            "Knowledgable",
            "New Person",
            "All-Star",
            "Data Expert",
            "Style Cop",
            "one who can exit VIM",
            "Conference Speaker",
            "Blogger",
        };

        public ushort UserHashIndex => 1;

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel technologyCharacterViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            var characterName = userViewModel?.Name?.Split(' ')?.FirstOrDefault();

            var suffix = _characterNameSuffixes[userHashValue];

            technologyCharacterViewModel.CharacterName = $"{characterName} the {suffix}";
        }
    }
}