using TechnologyCharacterGenerator.Child.Common.Models;
using TechnologyCharacterGenerator.Foundation.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public class CharacterClassTechnologyCharacterPropertyGenerator : ITechnologyCharacterPropertyGenerator
    {
        private readonly (string Class, ClassTypes ClassType)[] _characterClasses = {
            (Class:"Archer",    ClassType: ClassTypes.Agile),
            (Class:"Thief",     ClassType: ClassTypes.Agile),
            (Class:"Hunter",    ClassType: ClassTypes.Agile),
            (Class:"Rogue",     ClassType: ClassTypes.Agile),
            (Class:"Warrior",   ClassType: ClassTypes.Strong),
            (Class:"Barbarian", ClassType: ClassTypes.Strong),
            (Class:"Druid",     ClassType: ClassTypes.Strong),
            (Class:"Soldier",   ClassType: ClassTypes.Strong),
            (Class:"Wizard",    ClassType: ClassTypes.Magician),
            (Class:"Mage",      ClassType: ClassTypes.Magician),
            (Class:"Warlock",   ClassType: ClassTypes.Magician),
            (Class:"Sorceror",  ClassType: ClassTypes.Magician),
            (Class:"Paladin",   ClassType: ClassTypes.Healer),
            (Class:"Priest",    ClassType: ClassTypes.Healer),
            (Class:"Shaman",    ClassType: ClassTypes.Healer),
            (Class:"Healer",    ClassType: ClassTypes.Healer),
        };

        public ushort UserHashIndex => 0;

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel technologyCharacterViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            var characterClass = _characterClasses[userHashValue];

            technologyCharacterViewModel.Class = characterClass.Class;
            technologyCharacterViewModel.ClassType = characterClass.ClassType;
        }
    }
}