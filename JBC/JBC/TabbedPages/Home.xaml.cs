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
            //image.Source = ImageSource.FromResource("JBC.Images.jbcpcbackground.png");
            //welcomeLabel.text = "laldfhltjsldnflah";
        }
        

        async void AboutUs_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutUs());
        }

        async void Location_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Location());
        }

    }
}
