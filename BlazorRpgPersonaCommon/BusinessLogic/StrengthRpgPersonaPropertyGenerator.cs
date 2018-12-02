using BlazorRpgPersonaCommon.Models;

namespace BlazorRpgPersonaCommon.BusinessLogic
{
    public class StrengthRpgPersonaPropertyGenerator : IRpgPersonaPropertyGenerator
    {
        public ushort UserHashIndex => 3;
        public ushort Order => 10;

        public void GenerateRpgPersonaProperty(ref RpgPersonaViewModel rpgPersonaViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            rpgPersonaViewModel.Strength = userHashValue;
        }
    }
}