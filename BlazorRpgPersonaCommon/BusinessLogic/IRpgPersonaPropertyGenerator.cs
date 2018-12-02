using BlazorRpgPersonaCommon.Models;

namespace BlazorRpgPersonaCommon.BusinessLogic
{
    public interface IRpgPersonaPropertyGenerator
    {
        ushort UserHashIndex { get; }

        ushort Order { get; }

        void GenerateRpgPersonaProperty(ref RpgPersonaViewModel rpgPersonaViewModel, ushort userHashValue, UserViewModel userViewModel);
    }
}
