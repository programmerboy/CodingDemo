using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLoginSample.Helpers;
using MauiLoginSample.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        partial void OnPasswordChanged(string? oldValue, string newValue)
        {
            IsSignInButtonEnabled = UserName.HasValue() && Password.HasValue();
        }

        partial void OnUserNameChanged(string? oldValue, string newValue)
        {
            IsSignInButtonEnabled = UserName.HasValue() && Password.HasValue();
        }

        public MainViewModel()
        {
            Title = "Login Demo";
        }

        [RelayCommand]
        public async Task SignIn()
        {

        }


        [RelayCommand]
        public async Task CreateNew()
        {
            await MyUtilities.NavigateTo(new CreateAccountPage());
        }
    }
}
