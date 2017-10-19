using System;
using Xamarin.Forms;

namespace JBC
{
    public partial class News : ContentPage
    {
        public News()
        {
            InitializeComponent();

            var fb_html = new HtmlWebViewSource();

            //FBFeed.Source = fb_html;

            //FBFeed.Source = "https://www.powr.io/plugins/facebook-feed/view?unique_label=421d8127_1508346868&external_type=iframe";

            FBFeed.Source = "https://feed.mikle.com/widget/v2/50861/";

            FBFeed.Navigated += (s, e) => {

                FBFeed.Navigating += async (sender, eArg) =>
                {
                    eArg.Cancel = true;
                    var uri = new Uri(eArg.Url);
                    var answer = await DisplayAlert("Whoa!", "You're about to leave the JBC app.\nDo you want to continue?", "Yes", "No");

                    if (answer)
                        Device.OpenUri(uri);
                    
                };

            };

            /*FBFeed.Source = "https://www.juicer.io/api/feeds/jbcpumkincenter/iframe";

            FBFeed.Navigated += (s, e) => {

                FBFeed.Navigating += (sender, eArg) =>
                {
                    eArg.Cancel = true;
                    var uri = new Uri(eArg.Url);
                    Device.OpenUri(uri);
                };

            };*/
        }
    }
}
