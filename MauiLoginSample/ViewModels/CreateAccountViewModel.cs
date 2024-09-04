using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLoginSample.Helpers;
using MauiLoginSample.Models;
using MauiLoginSample.Services;

namespace MauiLoginSample.ViewModels
{
    public partial class CreateAccountViewModel : MyBaseViewModel
    {
        [ObservableProperty]
        AddNewUser addNewModel;

        [ObservableProperty]
        DateTime todaysDate;

        [ObservableProperty]
        DateTime maxDate;

        [ObservableProperty]
        string formValues;

        private IDataService service;

        public CreateAccountViewModel(IDataService service)
        {
            Title = "New Account";
            TodaysDate = DateTime.Now;
            MaxDate = TodaysDate.AddDays(30);
            AddNewModel = new AddNewUser();

            this.service = service;
        }

        partial void OnAddNewModelChanged(AddNewUser? oldValue, AddNewUser newValue)
        {

        }


        [RelayCommand]
        public async Task CreateAccount()
        {
            AddNewModel.UserName = AddNewModel.UserName.ToLower();

            var item = AddNewModel.CopyProperties<User>();

            var isSuccess = await service.AddUser(item);

            if (isSuccess)
            {
                await MyUtilities.NavigateToShell(AppConstants.ROUTE_NEW_USER_CREATED);
            }
            else
            {
                await MyUtilities.ShowToastAsync("User already exists!");
            }
        }
    }
}
