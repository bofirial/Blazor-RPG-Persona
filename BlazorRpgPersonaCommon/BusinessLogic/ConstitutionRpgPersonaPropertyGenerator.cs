using BlazorRpgPersonaCommon.Models;

namespace BlazorRpgPersonaCommon.BusinessLogic
{
    public class ConstitutionRpgPersonaPropertyGenerator : IRpgPersonaPropertyGenerator
    {
        public ushort UserHashIndex => 9;
        public ushort Order => 10;

        public void GenerateRpgPersonaProperty(ref RpgPersonaViewModel rpgPersonaViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            rpgPersonaViewModel.Constitution = userHashValue;
        }
    }
}