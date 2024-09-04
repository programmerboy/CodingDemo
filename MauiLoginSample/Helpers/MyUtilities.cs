using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLoginSample.Helpers
{
    internal static class MyUtilities
    {
        public static async Task NavigateTo(Page page)
        {
            //RemoveFromNavigation(page);
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public static async Task NavigateToShell(string route)
        {
            ShellNavigationState state = Shell.Current.CurrentState;
            await Shell.Current.GoToAsync(route);
            Shell.Current.FlyoutIsPresented = false;
        }

        public static void RemoveFromNavigation(Page page)
        {
            if (Application.Current.MainPage.Navigation.NavigationStack.Contains(page))
                Application.Current.MainPage.Navigation.RemovePage(page);
        }

        public static async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public static async Task GoBackShell()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
