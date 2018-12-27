using System;
using Microsoft.JSInterop;
using TechnologyCharacterGenerator.Foundation.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public class UserViewModelUpdateReceiver : IUserViewModelUpdateReceiver
    {
        public event Action<UserViewModel> UserViewModelUpdated;

        [JSInvokable]
        public void UpdateUserViewModel(UserViewModel userViewModel)
        {
            UserViewModelUpdated?.Invoke(userViewModel);
        }

        public event Action<UserViewModel> UserViewModelSubmitted;

        [JSInvokable]
        public void SubmitUserViewModel(UserViewModel userViewModel)
        {
            UserViewModelSubmitted?.Invoke(userViewModel);
        }
    }
}