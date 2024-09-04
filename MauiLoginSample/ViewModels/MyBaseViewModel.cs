using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiLoginSample.ViewModels
{
    public partial class MyBaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string? title;

        public bool IsNotBusy => !IsBusy;
    }
}
