using BlazorRpgPersonaCommon.Models;

namespace BlazorRpgPersonaCommon.BusinessLogic
{
    public class CharismaRpgPersonaPropertyGenerator : IRpgPersonaPropertyGenerator
    {
        public ushort UserHashIndex => 6;
        public ushort Order => 10;

        public void GenerateRpgPersonaProperty(ref RpgPersonaViewModel rpgPersonaViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            rpgPersonaViewModel.Charisma = userHashValue;
        }
    }
}