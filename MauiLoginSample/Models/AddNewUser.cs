using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLoginSample.Models
{
    public partial class AddNewUser : ObservableObject
    {
        [ObservableProperty]
        int id;

        [ObservableProperty]
        string firstName;

        [ObservableProperty]
        string lastName;

        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string phoneNumber;

        [ObservableProperty]
        DateTime serviceStartDate;
    }
}
