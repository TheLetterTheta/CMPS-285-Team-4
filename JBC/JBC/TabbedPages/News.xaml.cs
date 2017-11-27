using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JBC
{
    public partial class News : ContentPage
    {
        //public ObservableCollection<Data> AccountItems = new ObservableCollection<Data>();
        public News()
        {
            
            new FontButton(this);

            /*
            FacebookViewModel fbItems = new FacebookViewModel();
            BindingContext = fbItems;
            InitializeComponent();

            var itemsListView = new ListView();
            itemsListView.ItemsSource = fbItems;
            Content = itemsListView;
            

            /*
            ButtonGetItems.Clicked += async (sender, e) =>
            {
                ButtonGetItems.IsEnabled = false;
                GetAccountItemsAsync();
                ButtonGetItems.IsEnabled = true;
            };*//*
        }
    }
}
   */
            var facebookViewModel = new FacebookViewModel();

            BindingContext = facebookViewModel;

            var dataTemplate = new DataTemplate(() =>
            {
                var messageLabel = new Label
                {
                    TextColor = Color.Black,
                    FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label))

                };
                /*var created_timeLabel = new Label
                {
                    TextColor = Color.Black,
                    FontSize = 14
                };*/
                var fbMediaImage = new Image
                {
                    HeightRequest = GetImageHeight(FontButton.GetTextSize(0)),
                    WidthRequest = GetImageHeight(FontButton.GetTextSize(0))

                };


                /*
                var channelTitleLabel = new Label
                {
                    TextColor = Color.Maroon,
                    FontSize = 22

                };
                var titleLabel = new Label
                {
                    TextColor = Color.Black,
                    FontSize = 16
                };
                var descriptionLabel = new Label
                {
                    TextColor = Color.Gray,
                    FontSize = 14
                };*/


                messageLabel.SetBinding(Label.TextProperty, new Binding("Message"));
                //created_timeLabel.SetBinding(Label.TextProperty, new Binding("Created_Time", BindingMode.Default, null, null, "{0:MM-dd-yyy}"));
                fbMediaImage.SetBinding(Image.SourceProperty, new Binding("Picture"));


                var viewCell =  new ViewCell
                {
                    View = new StackLayout
                    {
                        BackgroundColor= Color.FromHex("#e6e6e6"),
                        Children = {
                            new Frame
                            {
                                BackgroundColor = Color.FromHex("#FFFFFF"),
                                CornerRadius = 2,
                                HasShadow = false,
                                Margin = new Thickness(10, 5, 10, 5),
                                Padding = new Thickness(20, 8, 20, 8),
                                Content = new StackLayout
                                {
                                    VerticalOptions = LayoutOptions.Center,
                                    Orientation = StackOrientation.Horizontal,
                                    //Padding = new Thickness(0, 10, 0, 10),
                                    Children =
                                    {
                                        fbMediaImage,

                                     new StackLayout
                                     {
                                        Padding = new Thickness(10, 0, 0, 0),
                                        VerticalOptions = LayoutOptions.Center,
                                        Orientation = StackOrientation.Vertical,
                                        Children =
                                        {
                                            messageLabel
                                        }
                                     }
                                  }
                                }
                            }
                        }
                    }
                };

                MessagingCenter.Subscribe<Application>(this, "Hi", (sender) => {

                    messageLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

                    fbMediaImage.HeightRequest = GetImageHeight(FontButton.GetTextSize(0));

                    fbMediaImage.WidthRequest = GetImageHeight(FontButton.GetTextSize(0));

                    viewCell.ForceUpdateSize();

                });

                return viewCell;

            });

            var listView = new ListView
            {
                HasUnevenRows = true

            };

            listView.SetBinding(ListView.ItemsSourceProperty, new Binding("FacebookItems"));

            listView.ItemTemplate = dataTemplate;

            //listView.ItemTapped += ListViewOnItemTapped;

            //listView.SeparatorColor = Color.Gray;

            listView.SeparatorVisibility = SeparatorVisibility.None;

            listView.BackgroundColor = Color.FromHex("#e6e6e6");
            


            Content = new StackLayout
            {
                //Padding = new Thickness(5, 10),
                Children =
                {
                    //label,
                    listView
                }
            };


        }

        private async void ListViewOnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            var item = itemTappedEventArgs.Group as Data;
            

            //Backgroundcolor = Color.Gray; //Show which video is clicked

            var answer = await DisplayAlert("Whoa!", "You're about to leave the JBC app.\nDo you want to continue?", "Yes", "No");

            //if (answer) 
            //Device.OpenUri(new Uri("https://www.youtube.com/watch?v=" + youtubeItem?.VideoId));


            // You can use Plugin.Share nuget package to open video in browser
            //CrossShare.Current.OpenBrowser("https://www.youtube.com/watch?v=" + youtubeItem?.VideoId);
        }

        private double GetImageHeight(NamedSize textSize)
        {

            switch (textSize)
            {

                case NamedSize.Micro: return 75;

                case NamedSize.Small: return 100;

                case NamedSize.Medium: return 125;

                default: return 100;

            }

        }

    }
}