using System;
using Xamarin.Forms;

namespace JBC
{
    public partial class JBCPage : TabbedPage
    {
        /*public static NamedSize[] textSize = { NamedSize.Micro, NamedSize.Small, NamedSize.Medium, NamedSize.Large };

        public static int currentSize = 1;*/

        private static bool tutorialBool = (Application.Current.Properties.ContainsKey("TutBool") ? Boolean.Parse(Application.Current.Properties["TutBool"].ToString()) : true);

        public JBCPage()
        {
            InitializeComponent();

            new FontButton(this);

            if(Device.RuntimePlatform == Device.Android)
            {
                this.ToolbarItems.Add(new ToolbarItem()
                {
                    Icon = "help.png",

                    Text = "Help",

                    Order = ToolbarItemOrder.Secondary,

                    Command = new Command(Tutorial_Button)
                });
            }

            if(tutorialBool){

                Navigation.PushAsync(new TutorialPage());

            }

            //fontSetting.Text = "Font: " + FontButton.textSize[FontButton.currentSize+1].ToString();

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

        public static bool GetTutorialBool()
        {
            return tutorialBool;
        }

        public static void SetTutorialBool(bool newTutBool)
        {
            tutorialBool = newTutBool;

            Application.Current.Properties["TutBool"] = tutorialBool;
        }

        void Tutorial_Button()
        {
            Navigation.PushAsync(new TutorialPage());
        }

        /*public void Handle_Activated(object sender, System.EventArgs e)
        {

            FontButton.Handle_Activated();
        }*/

        /*public static NamedSize GetTextSize(int offset)
        {
            if (currentSize + offset > 3 || FontButton.currentSize + offset < 0)
                offset = 0;
            return textSize[currentSize + offset];
        }*/
    }
}
