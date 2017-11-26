using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JBC
{

    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();

            WelcomeLabel.Text = "\tYou will find that in this church, we cherish God's Word and our mission is to lead people into a growing relationship with Jesus Christ. We exist to serve God's purpose for our generation. \n\tWe are glad that you have chosen to visit our site, and we sincerely hope that God will move you to share your spiritual journey with us. If you are new in the community, let us be among the first to welcome you to your new home, and extend to you a hearty invitation to make this your church home.";

            //btnFBlogo.Image = (FileImageSource)ImageSource.FromFile("FBlogo.png");

            //btnJBClogo.Image = (FileImageSource)ImageSource.FromFile("JBClogo.png");

            if (Device.RuntimePlatform == Device.iOS)
            {
                btnFBlogo.HeightRequest = 50;
                btnFBlogo.WidthRequest = 50;
                btnJBClogo.HeightRequest = 50;
                btnJBClogo.WidthRequest = 50;
            }
            else
            {
                btnFBlogo.HeightRequest = 55;
                btnFBlogo.WidthRequest = 55;
                btnJBClogo.HeightRequest = 55;
                btnJBClogo.WidthRequest = 55;
                btnTutorial.IsVisible = false;
            }

            btnTutorial.HeightRequest = 18;
            btnTutorial.WidthRequest = 18;

            var btnHeight = 40;

            setSizes(btnHeight);

            MessagingCenter.Subscribe<Application>(this, "Hi", (sender) =>
            {

                setSizes(btnHeight);

                btnFBlogo.Scale = 1 + (FontButton.currentSize * 0.1);

                btnJBClogo.Scale = 1 + (FontButton.currentSize * 0.1);

            });

            //image.Source = ImageSource.FromResource("JBC.Images.jbcpcbackground.png");
            //welcomeLabel.Text = "laldfhltjsldnflah";
        }

        void setSizes(int btnHeight)
        {

            Welcome.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

            WelcomeLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            connectLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

            btnAboutUs.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Button));

            btnLocation.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Button));

            btnAboutUs.HeightRequest = btnHeight + (FontButton.currentSize * 5);

            btnLocation.HeightRequest = btnHeight + (FontButton.currentSize * 5);

        }

        async void AboutUs_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutUs());
        }

        /*async void Location_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new Location());
        }*/

        async void Location_Clicked(object sender, EventArgs e)
        {

            var answer = await DisplayAlert("Leaving App!", "You're about to leave the JBC App to go to an outside site. Continue?", "Yes", "No");

            if (answer)
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    // opens Apple Maps app directly
                    Device.OpenUri(new Uri("http://maps.apple.com/?q=11109+Jerusalem+Church+Rd.+Hammond,+LA+70403"));
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    // opens Google Maps app directly
                    Device.OpenUri(new Uri("geo:0,0?q=11109+Jerusalem+Church+Rd.+Hammond,+LA+70403"));

                }
            }

        }

        async void FBlogo_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Leaving App!", "You're about to leave the JBC App to go to an outside site. Continue?", "Yes", "No");

            if (answer)
            {
                //code to go to facebook here
                Device.OpenUri(new Uri("https://www.facebook.com/jbcpumkincenter"));
            }
        }

        async void JBClogo_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Leaving App!", "You're about to leave the JBC App to go to an outside site. Continue?", "Yes", "No");

            if (answer)
            {
                //code to go to JBC website here
                Device.OpenUri(new Uri("http://jbcpc.org"));
            }
        }

        async void Tutorial_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TutorialPage());
        }
    }
}
