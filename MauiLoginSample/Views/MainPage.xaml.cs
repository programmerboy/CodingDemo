using MauiLoginSample.ViewModels;

namespace MauiLoginSample.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _viewmodel;

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();

            _viewmodel = viewModel;
            BindingContext = _viewmodel;
        }
    }

}
