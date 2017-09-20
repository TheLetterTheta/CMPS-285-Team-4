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
            image.Source = ImageSource.FromResource("JBC.Images.jbcpcbackground.png");
            
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
