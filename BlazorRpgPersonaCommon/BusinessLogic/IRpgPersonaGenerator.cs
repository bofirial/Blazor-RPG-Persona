using BlazorRpgPersonaCommon.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRpgPersonaCommon.BusinessLogic
{
    public interface IRpgPersonaGenerator
    {
        RpgPersonaViewModel GenerateRpgPersona(UserViewModel userViewModel);
    }
}
