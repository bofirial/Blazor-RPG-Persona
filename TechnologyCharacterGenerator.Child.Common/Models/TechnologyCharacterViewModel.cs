using System.Collections.Generic;
using System.ComponentModel;
using TechnologyCharacterGenerator.Foundation.Models;

//HACK: There appears to be an issue with the IL Generator in Blazor when using Generic Components that causes namespace issues.  Putting this model in the __Blazor namespace is a workaround.
namespace __Blazor.TechnologyCharacterGenerator.Child.Common.Models
{
    public class TechnologyCharacterViewModel
    {
        [DisplayName("Character Name")]
        public string CharacterName { get; set; }

        [DisplayName("Character Class")]
        public string Class { get; set; }

        [DisplayName("Hit Points")]
        public ushort HitPoints { get; set; }

        public ushort Strength { get; set; }

        public ushort Agility { get; set; }

        public ushort Intelligence { get; set; }

        public ushort Programming { get; set; }

        public ushort Testing { get; set; }

        public ushort Documentation { get; set; }

        public ushort Management { get; set; }

        public List<string> CharacterTraits { get; set; }

        public TechnologyCharacterAvatarModel TechnologyCharacterAvatar { get; set; }

        public string UserHash { get; set; }
    }
}
