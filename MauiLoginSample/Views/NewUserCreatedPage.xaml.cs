using MauiLoginSample.ViewModels;

namespace MauiLoginSample.Views;

public partial class NewUserCreatedPage : ContentPage
{
    private NewUserCreatedViewModel _viewmodel;

    public NewUserCreatedPage(NewUserCreatedViewModel viewModel)
    {
        InitializeComponent();
        _viewmodel = viewModel;
        BindingContext = _viewmodel;
    }
}