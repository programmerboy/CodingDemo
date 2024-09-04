using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLoginSample.Helpers;
using MauiLoginSample.Services;

namespace MauiLoginSample.ViewModels
{
    public partial class MainViewModel : MyBaseViewModel
    {
        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool isSignInButtonEnabled;
        private IDataService service;

        partial void OnPasswordChanged(string? oldValue, string newValue)
        {
            IsSignInButtonEnabled = UserName.HasValue() && Password.HasValue();
        }

        partial void OnUserNameChanged(string? oldValue, string newValue)
        {
            IsSignInButtonEnabled = UserName.HasValue() && Password.HasValue();
        }

        public MainViewModel(IDataService service)
        {
            Title = "Login Demo";
            this.service = service;
        }

        [RelayCommand]
        public async Task SignIn()
        {
            var user = await service.GetUser(UserName, Password);

            if (user is null)
            {
                await MyUtilities.ShowToastAsync($"Login unsuccessful for \"{UserName}\"");
            }
            else
            {
                await MyUtilities.ShowToastAsync($"Sign in successfull for \"{UserName}\". Welcome, {user.FirstName}!!");
            }
        }


        [RelayCommand]
        public async Task CreateNew()
        {
            await MyUtilities.NavigateToShell(AppConstants.ROUTE_NEW_USER);
        }
    }
}
