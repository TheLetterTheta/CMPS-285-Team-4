using Xamarin.Forms;
using JBC.Models;
using JBC.ViewModels;
using System;

namespace JBC
{
    public class YoutubeViewPage : ContentPage
    {

        public YoutubeViewPage()
        {

            Title = "Youtube";

            var youtubeViewModel = new YoutubeViewModel();

            BindingContext = youtubeViewModel;

            /*var label = new Label
            {
                Text = "Youtube",
                TextColor = Color.Gray,
                FontSize = 24
            };*/

            var dataTemplate = new DataTemplate(() =>
            {

                var channelTitleLabel = new Label
                {
                    TextColor = Color.Maroon,
                    FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label))

                };
                var titleLabel = new Label
                {
                    TextColor = Color.Black,
                    FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label))
                };
                var descriptionLabel = new Label
                {
                    TextColor = Color.Gray,
                    FontSize = Device.GetNamedSize(FontButton.GetTextSize(-1), typeof(Label))
                };

                /*var viewCountLabel = new Label
                {
                    TextColor = Color.FromHex("#0D47A1"),
                    FontSize = 14
                };
                var likeCountLabel = new Label
                {
                    TextColor = Color.FromHex("#2196F3"),
                    FontSize = 14
                };
                var dislikeCountLabel = new Label
                {
                    TextColor = Color.FromHex("#0D47A1"),
                    FontSize = 14
                };
                var favoriteCountLabel = new Label
                {
                    TextColor = Color.FromHex("#2196F3"),
                    FontSize = 14
                };
                var commentCountLabel = new Label
                {
                    TextColor = Color.FromHex("#0D47A1"),
                    FontSize = 14
                };*/
                var mediaImage = new Image
                {

                    HeightRequest = GetImageHeight(FontButton.GetTextSize(0))

                };

                /*MessagingCenter.Subscribe<Application>(this, "Hi", (sender) => {

                    channelTitleLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

                    titleLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

                    descriptionLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(-1), typeof(Label));

                    mediaImage.HeightRequest = GetImageHeight(FontButton.GetTextSize(0));

                });*/

                channelTitleLabel.SetBinding(Label.TextProperty, new Binding("ChannelTitle"));
                titleLabel.SetBinding(Label.TextProperty, new Binding("Title"));
                descriptionLabel.SetBinding(Label.TextProperty, new Binding("Description"));
                mediaImage.SetBinding(Image.SourceProperty, new Binding("HighThumbnailUrl"));
                /*viewCountLabel.SetBinding(Label.TextProperty, new Binding("ViewCount", BindingMode.Default, null, null, "{0:n0} views"));
                likeCountLabel.SetBinding(Label.TextProperty, new Binding("LikeCount", BindingMode.Default, null, null, "{0:n0} likes"));
                dislikeCountLabel.SetBinding(Label.TextProperty, new Binding("DislikeCount", BindingMode.Default, null, null, "{0:n0} dislike"));
                commentCountLabel.SetBinding(Label.TextProperty, new Binding("CommentCount", BindingMode.Default, null, null, "{0:n0} comments"));
                favoriteCountLabel.SetBinding(Label.TextProperty, new Binding("FavoriteCount", BindingMode.Default, null, null, "{0:n0} favorite"));*/

                var viewCell = new ViewCell
                {
                    View = new StackLayout{

                        Children = {
                            new Frame
                            {
                                BackgroundColor = Color.FromHex("#FFFFFF"),
                                CornerRadius = 2,
                                HasShadow = false,
                                Margin = new Thickness(10, 5, 10, 5),
                                Content = new StackLayout
                                {
                                    VerticalOptions = LayoutOptions.Center,
                                    Orientation = StackOrientation.Horizontal,
                                    //Padding = new Thickness(0, 0, 0, 20),
                                    Children =
                                    {
                                        //channelTitleLabel,
                                        /*new StackLayout
                                        {
                                            Orientation = StackOrientation.Horizontal,
                                            Children =
                                            {
                                                viewCountLabel,
                                                likeCountLabel,
                                                dislikeCountLabel,
                                            }
                                        },
                                        new StackLayout
                                        {
                                            Orientation = StackOrientation.Horizontal,
                                            TranslationY = -7,
                                            Children =
                                            {
                                                favoriteCountLabel,
                                                commentCountLabel
                                            }
                                        },*/
                                        mediaImage,

                                     new StackLayout
                                     {
                                        Padding = new Thickness(10, 0, 0, 0),
                                        VerticalOptions = LayoutOptions.Center,
                                        Orientation = StackOrientation.Vertical,
                                        Children =
                                        {
                                           titleLabel,
                                           descriptionLabel
                                        }
                                     }
                                  }
                                }
                            }
                        }
                    }
                };

                MessagingCenter.Subscribe<Application>(this, "Hi", (sender) => {

                    channelTitleLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

                    titleLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

                    descriptionLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(-1), typeof(Label));

                    mediaImage.HeightRequest = GetImageHeight(FontButton.GetTextSize(0));

                    viewCell.ForceUpdateSize();

                });

                return viewCell;
            });

            var listView = new ListView
            {
                HasUnevenRows = true

            };

            listView.SetBinding(ListView.ItemsSourceProperty, "YoutubeItems");

            listView.ItemTemplate = dataTemplate;

            listView.ItemTapped += ListViewOnItemTapped;

            //listView.SeparatorColor = Color.Gray;

            listView.SeparatorVisibility = SeparatorVisibility.None;

            listView.BackgroundColor = Color.FromHex("#e6e6e6");



            Content = new StackLayout
            {
                Children =
                {
                    //label,
                    listView
                }
            };
        }

        private async void ListViewOnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            var youtubeItem = itemTappedEventArgs.Item as YoutubeItem;

            //BackgroundColor = Color.Gray; //Show which video is clicked
            

            var answer = await DisplayAlert("Hey!", "We're taking you to the Youtube app or website! \n Do you want to continue?", "Yes", "No");

            if (answer)
                Device.OpenUri(new Uri("https://www.youtube.com/watch?v=" + youtubeItem?.VideoId));


            // You can use Plugin.Share nuget package to open video in browser
            //CrossShare.Current.OpenBrowser("https://www.youtube.com/watch?v=" + youtubeItem?.VideoId);
        }

        private int GetImageHeight(NamedSize textSize){

            switch (textSize)
            {

                case NamedSize.Micro: return 50;

                case NamedSize.Small: return 75;

                case NamedSize.Medium: return 100;

                default: return 75;

            }

        }
    }
}

///// if you prefer to work with XAML code, 
///// use the following which is similar to the above code


//  <ContentPage.BindingContext>
//    <viewModels:YoutubeViewModel/>
//  </ContentPage.BindingContext>

//  <StackLayout Padding = "5,10"
//               BackgroundColor="White">

//    <Label Text = "Youtube"
//           TextColor="Black"
//           FontSize="22"/>

//    <ListView ItemsSource = "{Binding YoutubeItems}"
//              HasUnevenRows="True">
//      <ListView.ItemTemplate>
//        <DataTemplate>
//          <ViewCell>

//            <StackLayout Orientation = "Vertical"
//                         Padding="10,10,10,20">
//              <Label Text = "{Binding ChannelTitle}"
//                     TextColor="Maroon"
//                     FontSize="22"/>
//              <StackLayout Orientation = "Horizontal" >
//                < Label Text="{Binding ViewCount, StringFormat='{0:n0} views'}"
//                       TextColor="#0D47A1"
//                       FontSize="14"/>
//                <Label Text = "{Binding LikeCount, StringFormat='{0:n0} likes'}"
//                       TextColor="#2196F3"
//                       FontSize="14"/>
//                <Label Text = "{Binding DislikeCount, StringFormat='{0:n0} dislikes'}"
//                         TextColor="#0D47A1"
//                         FontSize="14"/>
//              </StackLayout>
//              <StackLayout Orientation = "Horizontal"
//                           TranslationY="-7">
//                <Label Text = "{Binding FavoriteCount, StringFormat='{0:n0} favorites'}"
//                      TextColor="#2196F3"
//                      FontSize="14"/>
//                <Label Text = "{Binding CommentCount, StringFormat='{0:n0} comments'}"
//                       TextColor="#0D47A1"
//                       FontSize="14"/>
//              </StackLayout>
//              <Label Text = "{Binding Title}"
//                     TextColor="Black"
//                     FontSize="16"/>
//              <Image Source = "{Binding HighThumbnailUrl}"
//                     HeightRequest="200"/>
//              <Label Text = "{Binding Description}"
//                     TextColor="Gray"
//                     FontSize="14"/>
//            </StackLayout>

//          </ViewCell>
//        </DataTemplate>
//      </ListView.ItemTemplate>
//    </ListView>
//  </StackLayout>