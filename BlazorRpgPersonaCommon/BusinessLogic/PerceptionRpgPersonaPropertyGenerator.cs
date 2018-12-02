using BlazorRpgPersonaCommon.Models;

namespace BlazorRpgPersonaCommon.BusinessLogic
{
    public class PerceptionRpgPersonaPropertyGenerator : IRpgPersonaPropertyGenerator
    {
        public ushort UserHashIndex => 10;
        public ushort Order => 10;

        public void GenerateRpgPersonaProperty(ref RpgPersonaViewModel rpgPersonaViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            rpgPersonaViewModel.Perception = userHashValue;
        }
    }
}