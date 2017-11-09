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

            Welcome.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

            WelcomeLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            connectLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

            WelcomeLabel.Text = "\tYou will find that in this church, we cherish God's Word and our mission is to lead people into a growing relationship with Jesus Christ. We exist to serve God's purpose for our generation. \n\tWe are glad that you have chosen to visit our site, and we sincerely hope that God will move you to share your spiritual journey with us. If you are new in the community, let us be among the first to welcome you to your new home, and extend to you a hearty invitation to make this your church home.";

            MessagingCenter.Subscribe<Application>(this, "Hi", (sender) => {

                Welcome.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

                WelcomeLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

                connectLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

            });


            btnFBlogo.Image = (FileImageSource)ImageSource.FromFile("FBlogo.png");
            btnJBClogo.Image = (FileImageSource)ImageSource.FromFile("JBClogo.png");
            if(Device.RuntimePlatform == Device.iOS){
                btnFBlogo.HeightRequest = 50;
				btnFBlogo.WidthRequest = 50;
				btnJBClogo.HeightRequest = 50;
				btnJBClogo.WidthRequest = 50;
            }
            else{
                btnFBlogo.HeightRequest = 55;
                btnFBlogo.WidthRequest = 55;
                btnJBClogo.HeightRequest = 55;
                btnJBClogo.WidthRequest = 55;
            }

            //image.Source = ImageSource.FromResource("JBC.Images.jbcpcbackground.png");
            //welcomeLabel.Text = "laldfhltjsldnflah";
        }
        

        async void AboutUs_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutUs());
        }

        /*async void Location_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new Location());
        }*/

        async void Location_Clicked(object sender, EventArgs e){
			
			var answer = await DisplayAlert("Whoa!", "You're about to leave the JBC app.\nDo you want to continue?", "Yes", "No");

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
			var answer = await DisplayAlert("Whoa!", "You're about to leave the JBC app.\nDo you want to continue?", "Yes", "No");

            if (answer)
            {
                //code to go to facebook here
                Device.OpenUri(new Uri("https://www.facebook.com/jbcpumkincenter"));
            }
        }

        async void JBClogo_Clicked(object sender, EventArgs e)
        {
			var answer = await DisplayAlert("Whoa!", "You're about to leave the JBC app.\nDo you want to continue?", "Yes", "No");

            if (answer)
            {
                //code to go to JBC website here
                Device.OpenUri(new Uri("http://jbcpc.org"));
            }
        }
    }
}
