using CommunityToolkit.Mvvm.Input;
using MauiLoginSample.Helpers;

namespace MauiLoginSample.ViewModels
{
    public partial class NewUserCreatedViewModel : MyBaseViewModel
    {
        public NewUserCreatedViewModel()
        {
            Title = "Success";
        }

        [RelayCommand]
        public async Task GoToSignInPage()
        {
            await MyUtilities.NavigateToShell(AppConstants.ROUTE_MAIN);
        }
    }
}
