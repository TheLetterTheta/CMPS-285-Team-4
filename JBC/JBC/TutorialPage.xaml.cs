using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JBC
{
    public partial class TutorialPage : ContentPage
    {
        public TutorialPage()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);

            new FontButton(this);

            //FontImage.Source = ImageSource.FromResource("JBC.Images..jpg");
            FontImage.Source = Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("fontSize.png") : ImageSource.FromFile("fontSize.png");

            TabsImage.Source = Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("DroidTabs.png") : ImageSource.FromFile("iOSTabs.png");

            Thanks.Text = "Thank you for downloading the Jerusalem Baptist Church Member Companion App!\n";

            Tabs.Text = "Upon the dismissal of this tutorial you will see tabs located at the bottom of the app. These tabs will bring you between " +
                        "the four main sections of the app detailed below: \n\n - Home: The Home tab takes you to the main hub where you can access the About Us page " +
                "and the Location as well as the church website and facebook page.\n\n - Notes: The Notes tab allows you to view sermon notes.\n\n - News: The News tab will have " +
                "recent announcements from your Pastor.\n\n - Videos: The Videos tab will allow you to watch videos of previous sermons.";

            FontChange.Text = "Located at the top-right of the app is a button that allows you to change the font size for easier viewing depending on your device.\n";

            Dismiss.Text = "Tap the dismiss button when you are ready to continue into the app.";
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
