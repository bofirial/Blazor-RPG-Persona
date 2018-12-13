using BlazorRpgPersona.Models;
using BlazorRpgPersonaCommon.Models;

namespace BlazorRpgPersonaCommon.BusinessLogic
{
    public class WisdomRpgPersonaPropertyGenerator : IRpgPersonaPropertyGenerator
    {
        public ushort UserHashIndex => 7;
        public ushort Order => 10;

        public void GenerateRpgPersonaProperty(ref RpgPersonaViewModel rpgPersonaViewModel, ushort userHashValue,
            UserViewModel userViewModel)
        {
            rpgPersonaViewModel.Wisdom = userHashValue;
        }
    }
}