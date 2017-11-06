using System;
using Xamarin.Forms;

namespace JBC
{
    public partial class JBCPage : TabbedPage
    {
        static NamedSize[] textSize = { NamedSize.Micro, NamedSize.Small, NamedSize.Medium, NamedSize.Large };

        static int currentSize = 2;

        public JBCPage()
        {
            InitializeComponent();

            fontSetting.Text = "Font: " + textSize[currentSize].ToString();

            //codebehind for making home page a navigation page...

            // var navigationPage = new NavigationPage(new Home());
            // navigationPage.Title = "Home";
            //Children.Add(new Notes());
            //Children.Add(new News());
            //Children.Add(new Videos());
            //if(Device.RuntimePlatform == Device.iOS)
            //    BarBackgroundColor = Color.White;
            //else
            //    BackgroundColor = Color.FromHex("#990000");
        }

        void Handle_Activated(object sender, System.EventArgs e)
        {

            if (currentSize == 2)
            {
                currentSize = 0;
            }
            else
            {
                currentSize += 1;
            }

            fontSetting.Text = "Font: " + textSize[currentSize].ToString();

            MessagingCenter.Send<JBCPage>(this, "Hi");
        }

        public static NamedSize GetTextSize(int offset)
        {
            if (currentSize + offset > 3)
                offset = 0;
            return textSize[currentSize + offset];
        }
    }
}
