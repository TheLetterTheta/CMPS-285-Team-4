using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JBC
{
    public partial class Videos : ContentPage
    {
        public Videos()
        {
            InitializeComponent();
            // var contentPage = new ContentPage(YoutubeViewPage);

            var yt_html_source = new HtmlWebViewSource();

            //yt_html_source.Html = "<html><body><iframe src=\"https://www.powr.io/plugins/youtube-gallery/view?unique_label=a60ab587_1508344580&external_type=iframe\" width=\"100%\" height=\"2000\" frameborder=\"0\"></iframe></body></html>";

            //videoWV.Source = yt_html_source;

            videoWV.Source = "https://www.powr.io/plugins/youtube-gallery/view?unique_label=a60ab587_1508344580&external_type=iframe";
        }
    }
}
