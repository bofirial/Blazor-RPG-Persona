using System;

namespace TechnologyCharacterGenerator.Foundation.Models
{
    public class ChildApplicationStatusViewModel
    {
        public string ApplicationName { get; set; }

        public DateTime ApplicationLoadStartedOn { get; set; }

        public DateTime ApplicationLoadCompletedOn { get; set; }

        public DateTime CharacterGenerationStartedOn { get; set; }

        public DateTime CharacterGenerationCompletedOn { get; set; }
    }
}