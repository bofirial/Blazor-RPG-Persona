using TechnologyCharacterGenerator.Foundation.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public class TechnologyCharacterTraitGenerator : ITechnologyCharacterPropertyGenerator
    {
        public TechnologyCharacterTraitGenerator(ushort userhashIndex, ushort requiredThreshold, string characterTrait)
        {
            UserHashIndex = userhashIndex;
            RequiredThreshold = requiredThreshold;
            CharacterTrait = characterTrait;
        }

        public ushort UserHashIndex { get; }
        public ushort RequiredThreshold { get; }
        public string CharacterTrait { get; }
        
        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel technologyCharacterViewModel, ushort userHashValue, UserViewModel userViewModel)
        {
            if (userHashValue >= RequiredThreshold)
            {
                technologyCharacterViewModel.CharacterTraits.Add(CharacterTrait);
            }
        }
    }
}
