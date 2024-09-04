using MauiLoginSample.Helpers;
using MauiLoginSample.Views;

namespace MauiLoginSample
{
    public partial class AppShell : Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();

        public Dictionary<string, Type> Routes { get { return routes; } }

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();

        }

        void RegisterRoutes()
        {
            routes.Add(AppConstants.ROUTE_MAIN, typeof(MainPage));
            routes.Add(AppConstants.ROUTE_NEW_USER, typeof(CreateAccountPage));
            routes.Add(AppConstants.ROUTE_NEW_USER_CREATED, typeof(NewUserCreatedPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        protected async override void OnNavigating(ShellNavigatingEventArgs e)
        {
            base.OnNavigating(e);

            try
            {
                // cancel any back navigation
                if (e.Source == ShellNavigationSource.Pop || e.Source == ShellNavigationSource.PopToRoot || e.Source == ShellNavigationSource.Unknown)
                {
                    var routeOrLocation = e.Current.Location.ToString();
                    var targetLocation = e.Target.Location.OriginalString;

                    var routeLastPart = routeOrLocation.GetLastPart('/');
                    var targetLastPart = targetLocation.GetLastPart('/');
                    var routeHierarchy = routeOrLocation.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                    if (AppConstants.ROUTE_NEW_USER_CREATED.GetLastPart('/').ExactMatch(routeLastPart) && targetLastPart.Equals(".."))
                    {
                        e.Cancel();
                        await MyUtilities.NavigateToShell(AppConstants.ROUTE_MAIN);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
