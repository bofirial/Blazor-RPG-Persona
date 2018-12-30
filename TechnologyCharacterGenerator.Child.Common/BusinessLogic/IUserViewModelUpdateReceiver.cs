using System;
using TechnologyCharacterGenerator.Foundation.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public interface IUserViewModelUpdateReceiver
    {
        event Action<UserViewModel> UserViewModelUpdated;

        void UpdateUserViewModel(UserViewModel userViewModel);

        event Action<UserViewModel> UserViewModelSubmitted;

        void SubmitUserViewModel(UserViewModel userViewModel);
    }
}
