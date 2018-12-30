using System.Threading.Tasks;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public interface IApplicationNameProvider
    {
        Task<string> GetApplicationNameAsync();
    }
}
