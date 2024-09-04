using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLoginSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [ObservableProperty]
        private bool shouldCreateAccountButtonBeEnabled;

        public CreateAccountViewModel()
        {
            Title = "New Account";
            TodaysDate = DateTime.Now;
            MaxDate = TodaysDate.AddDays(30);
            AddNewModel = new AddNewUser();
        }

        partial void OnAddNewModelChanged(AddNewUser? oldValue, AddNewUser newValue)
        {

        }


        [RelayCommand]
        public async Task CreateAccount()
        {
            FormValues = $"{AddNewModel.FirstName}\n" +
                   $"{AddNewModel.LastName}\n" +
                    $"{AddNewModel.UserName}\n" +
                     $"{AddNewModel.Password}\n" +
                     $"{AddNewModel.PhoneNumber}\n";
        }
    }
}
