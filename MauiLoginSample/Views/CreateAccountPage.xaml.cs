using MauiLoginSample.ViewModels;

namespace MauiLoginSample.Views;

public partial class CreateAccountPage : ContentPage
{
    private CreateAccountViewModel _viewmodel;

    public CreateAccountPage(CreateAccountViewModel viewModel)
    {
        InitializeComponent();
        _viewmodel = viewModel;
        BindingContext = _viewmodel;
    }
}