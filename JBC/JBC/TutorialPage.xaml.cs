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

            new FontButton(this);

            if (JBCPage.GetTutorialBool())
            {
                NavigationPage.SetHasBackButton(this, false);
                Thanks.IsVisible = true;
                Dismiss.IsVisible = true;
                DismissBtn.IsVisible = true;
                Tabs.IsVisible = true;
            }
            else if (!JBCPage.GetTutorialBool())
            {
                NavigationPage.SetHasBackButton(this, true);
                Thanks.IsVisible = false;
                Dismiss.IsVisible = false;
                DismissBtn.IsVisible = false;
                Tabs.IsVisible = false;
            }

            SetSizes();

            MessagingCenter.Subscribe<Application>(this, "Hi", (sender) => SetSizes());

            //FontImage.Source = ImageSource.FromResource("JBC.Images..jpg");
            FontImage.Source = ImageSource.FromFile("fontSize.png");

            //FontImage.WidthRequest = 50;

            TapGestureRecognizer tapEvent = new TapGestureRecognizer();
            tapEvent.Tapped += Font_Clicked;
            FontImage.GestureRecognizers.Add(tapEvent);

            //TabsImage.Source = Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("DroidTabs.png") : ImageSource.FromFile("iOSTabs.png");

            Thanks.Text = "\nThank you for downloading the Jerusalem Baptist Church Member Companion App!\n";

            Tabs.Text = "Upon the dismissal of this tutorial you will see tabs located at the top or bottom of the app. These tabs will bring you between " +
                        "the four main sections of the app detailed below: \n";

            Home.Text = "The Home tab takes you to the main hub where you can access the About Us page " +
                        "and the Location as well as the church website and facebook page.";

            Notes.Text = "The Notes tab allows you to view sermon notes.";

            News.Text = "The News tab will have recent announcements from your Pastor.";

            Videos.Text = "The Videos tab will allow you to watch videos of previous sermons.";

            FontChange.Text = "Located at the top-right of the app is a button that allows you to change the font size for easier viewing depending on your device.\n";

            Dismiss.Text = "Tap the dismiss button when you are ready to continue into the app.";
        }

        void SetSizes()
        {

            Thanks.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            TabsTitle.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

            Tabs.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            Home.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            Notes.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            News.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            Videos.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            FontChangeTitle.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

            FontChange.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            Dismiss.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            //FontImage.Scale = (1 + (FontButton.currentSize * 0.01));

            switch(FontButton.currentSize){

                case 0:  FontImage.Margin = 5; break;
                
                case 1: FontImage.Margin = 10; break;

                case 2: FontImage.Margin = 15; break;

                default: FontImage.Margin = 10; break;

            }

            switch (FontButton.currentSize)
            {

                case 0: tutHome.HeightRequest = 45; tutNotes.HeightRequest = 45; tutNews.HeightRequest = 45; tutVideos.HeightRequest = 45; FontImage.HeightRequest = 25; FontImage.WidthRequest = 25; FontImageStack.HeightRequest = 40; FontImageStack.WidthRequest = 40; break;

                case 1: tutHome.HeightRequest = 55; tutNotes.HeightRequest = 55; tutNews.HeightRequest = 55; tutVideos.HeightRequest = 55; FontImage.HeightRequest = 35; FontImage.WidthRequest = 35; FontImageStack.HeightRequest = 50; FontImageStack.WidthRequest = 50; break;

                case 2: tutHome.HeightRequest = 65; tutNotes.HeightRequest = 65; tutNews.HeightRequest = 65; tutVideos.HeightRequest = 65; FontImage.HeightRequest = 45; FontImage.WidthRequest = 45; FontImageStack.HeightRequest = 60; FontImageStack.WidthRequest = 60; break;

                default: tutHome.HeightRequest = 55; tutNotes.HeightRequest = 55; tutNews.HeightRequest = 55; tutVideos.HeightRequest = 55; FontImage.HeightRequest = 35; FontImage.WidthRequest = 35; FontImageStack.HeightRequest = 50; FontImageStack.WidthRequest = 50; break;

            }

        }

        void Font_Clicked(object sender, System.EventArgs e)
        {
            FontButton.Handle_Activated();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();

            JBCPage.SetTutorialBool(false);
        }
    }
}
