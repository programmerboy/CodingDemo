using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLoginSample.Helpers;
using MauiLoginSample.Services;

namespace MauiLoginSample.ViewModels
{
    public partial class MainViewModel : MyBaseViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(EnableSignInButton))]
        private string userName;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(EnableSignInButton))]
        private string password;

        private IDataService service;

        public bool EnableSignInButton => UserName.HasValue() && Password.HasValue();

        partial void OnUserNameChanged(string? oldValue, string newValue)
        { }

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
