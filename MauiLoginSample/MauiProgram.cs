using CommunityToolkit.Maui;
using MauiLoginSample.Helpers;
using MauiLoginSample.Services;
using MauiLoginSample.ViewModels;
using MauiLoginSample.Views;
using Microsoft.Extensions.Logging;

namespace MauiLoginSample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", OTDFontFamilies.OpenSansRegular);
                    fonts.AddFont("OpenSans-Semibold.ttf", OTDFontFamilies.OpenSansSemibold);
                    fonts.AddFont("typicons.ttf", OTDFontFamilies.OTDTypicons);
                    fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", OTDFontFamilies.FontAwesomeBrands);
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            RegisterEssentials(builder.Services);
            RegisterViewsAndViewModels(builder.Services);

            return builder.Build();
        }

        private static void RegisterEssentials(IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>();

            services.AddSingleton(Connectivity.Current);
            services.AddSingleton(Geolocation.Default);
            services.AddSingleton(Map.Default);

            //Picked from MAUI Community Toolkit
            services.AddSingleton(DeviceDisplay.Current);
            services.AddSingleton(DeviceInfo.Current);
        }

        private static void RegisterViewsAndViewModels(IServiceCollection services)
        {

            //services.AddSingleton<MainPage, MainViewModel>();
            services.AddTransient<MainPage, MainViewModel>();
            services.AddTransient<CreateAccountPage, CreateAccountViewModel>();
            services.AddTransient<NewUserCreatedPage, NewUserCreatedViewModel>();

            /*services.AddTransient<NearYouPage, ListItemViewModel>();
            services.AddTransient<HelpPage, HelpViewModel>();*/
        }
    }
}
