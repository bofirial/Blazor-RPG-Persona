using TechnologyCharacterGenerator.Foundation.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public class CharacterClassTechnologyCharacterPropertyGenerator : ITechnologyCharacterPropertyGenerator
    {
        private readonly string[] _characterClasses = new[]
            {
                "Application Developer",
                "Web Developer",    
                "Domain Architect",   
                "Database Administrator",    
                "Software Quality Analyst",  
                "Application Engineer",
                "Enterprise Architect",    
                "Chief Technology Officer",  
                "Director of Information Technology",   
                "Information Technology Manager",     
                "Technical Lead",  
                "Information Technology Team Lead", 
                "Intern",  
                "Systems Administrator",   
                "Chief Information Officer",   
                "Information Security Specialist",   
            };

        public ushort UserHashIndex => 0;

        public void GenerateTechnologyCharacterProperty(ref TechnologyCharacterViewModel technologyCharacterViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            var characterClass = _characterClasses[userHashValue];

            technologyCharacterViewModel.Class = characterClass;
        }
    }
}