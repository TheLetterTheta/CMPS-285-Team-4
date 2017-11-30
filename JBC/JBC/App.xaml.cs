using Xamarin.Forms;

namespace JBC
{
    public partial class App : Application
    {
        public static double ScreenWidth;
        public static double ScreenHeight;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new JBCPage())
            {
                BarBackgroundColor = Color.FromHex("#990000"),
                BarTextColor = Color.White
            };
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
