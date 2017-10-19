using Xamarin.Forms;

namespace JBC
{
    public partial class News : ContentPage
    {
        public News()
        {
            InitializeComponent();

            var fb_html = new HtmlWebViewSource();

            fb_html.Html = "<html><body><iframe src=\"https://www.powr.io/plugins/facebook-feed/view?unique_label=421d8127_1508346868&external_type=iframe\" width=\"100%\" height=\"2500\" frameborder=\"0\"></iframe></body></html>";

            //FBFeed.Source = fb_html;

            FBFeed.Source = "https://www.powr.io/plugins/facebook-feed/view?unique_label=421d8127_1508346868&external_type=iframe";
        }
    }
}
