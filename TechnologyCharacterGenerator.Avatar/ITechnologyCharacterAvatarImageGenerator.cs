using TechnologyCharacterGenerator.Foundation.Models;

namespace TechnologyCharacterGenerator.Avatar
{
    public interface ITechnologyCharacterAvatarImageGenerator
    {
        TechnologyCharacterAvatarImage GenerateTechnologyCharacterAvatarImage(TechnologyCharacterAvatarModel model);
    }
}
