using System.Collections.Generic;
using System.Linq;
using TechnologyCharacterGenerator.Foundation.Models;
using TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public class CharacterNameTechnologyCharacterPropertyGenerator : ITechnologyCharacterPropertyGenerator
    {
        private readonly Dictionary<ClassTypes, string[]> _characterNameSuffixes = new Dictionary<ClassTypes, string[]>()
        {
            {
                ClassTypes.Healer,  new[]
                {
                    "Natural",
                    "Spiritual",
                    "Righteous",
                    "Faithful",
                    "Pious",
                    "Penetant",
                    "Holy",
                    "Devout",
                    "Religious",
                    "Dutiful",
                    "Saint",
                    "Prayerful",
                    "Soulful",
                    "Angel",
                    "Martyr",
                    "Beloved",
                }
            },
            {
                ClassTypes.Magician, new[]
                {
                    "Arcane",
                    "Magical",
                    "Elemental",
                    "Enchanter",
                    "Flaming",
                    "Intelligent",
                    "Thunderous",
                    "God of Thunder",
                    "God of Fire",
                    "God of Frost",
                    "Summoner",
                    "Conjuror",
                    "Destroyer of Worlds",
                    "Illustrious",
                    "Effervescent",
                    "Mysterious",
                }
            },
            {
                ClassTypes.Strong,  new[]
                {
                    "Challenger",
                    "Brave",
                    "Brutal",
                    "Strong",
                    "Mighty",
                    "Bold",
                    "Champion",
                    "Weapon Master",
                    "Fierce",
                    "Axe",
                    "Sword",
                    "Long-Arm",
                    "Swift",
                    "Battle-Hardy",
                    "Eager",
                    "Giant",
                }
            },
            {
                ClassTypes.Agile,   new[]
                {
                    "Schemer",
                    "Scoundral",
                    "Agile",
                    "Dexterous",
                    "Quick",
                    "Accurate",
                    "Sneaky",
                    "Stealthy",
                    "Rich",
                    "Nimble",
                    "Sure-Footed",
                    "Wild",
                    "Acrobatic",
                    "Precise",
                    "Perfect",
                    "Skillful",
                }
            },
        };

        public ushort UserHashIndex => 1;
        public ushort Order => 20;

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel TechnologyCharacterViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            var characterName = userViewModel.Name.Split(' ').FirstOrDefault();

            var suffix = _characterNameSuffixes[TechnologyCharacterViewModel.ClassType][userHashValue];

            TechnologyCharacterViewModel.CharacterName = $"{characterName} the {suffix}";
        }
    }
}