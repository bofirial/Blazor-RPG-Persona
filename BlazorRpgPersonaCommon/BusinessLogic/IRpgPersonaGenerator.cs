using BlazorRpgPersonaCommon.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRpgPersona.Models;

namespace BlazorRpgPersonaCommon.BusinessLogic
{
    public interface IRpgPersonaGenerator
    {
        RpgPersonaViewModel GenerateRpgPersona(UserViewModel userViewModel);
    }
}
