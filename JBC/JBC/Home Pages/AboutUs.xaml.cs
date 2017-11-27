using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JBC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutUs : ContentPage
    {
        public AboutUs()
        {
            InitializeComponent();

            //fontSetting.Text = "Font: " + FontButton.textSize[FontButton.currentSize + 1].ToString();

            new FontButton(this);

            SetAboutSize();

            MessagingCenter.Subscribe<Application>(this, "Hi", (sender) => {

                SetAboutSize();

            });

            AboutLabel.Text = "At Jerusalem Baptist Church, it’s our desire to be an open and welcoming place for community life and worship. " +
                "We invite you to join us as we serve together for God’s glory. I believe that you’ll find Jerusalem Baptist Church to be a place where God is worshiped sincerely, Jesus Christ is preached triumphantly, " +
                "His resurrection is celebrated joyously, the Gospel is shared unashamedly, and the Holy Spirit moves freely! I believe JBC is the place where you will find the help you need to overcome any physical obstacles, " +
                "the healing to conquer any emotional hurts or struggles, and the hope to experience spiritual encouragement and a renewed purpose for living in Jesus Christ! Please join us for our weekly activities and special events. " +
                "I’d love to share with you more about how you can become a part of the JBC family! I look forward to meeting you and pray God’s richest blessings upon you! \n\nIn Christ’s service, \n Dr. Phil Weaver, pastor\n";
            Pastor.Source = ImageSource.FromResource("JBC.Images.Dr._Phil__Kim_Weaver.jpg");
            AddressLabel.Text = "11109 Jerusalem Baptist Church Road \n Hammond, Louisiana 70403";
            OfficeHoursLabel.Text = "Monday-Thursday: 9:00am - 4:00pm" + "\n" + "(Lunch Break: 12:00pm - 1:00pm)" + "\n" + "Friday: Closed" + "\n";
            NumberLabel.Text = "Phone: (225) 294-2001 \n Fax: (225) 294-2020";
            TimesLabel.Text = "Sunday: \n Sunday School (Bible Study) at 9:15am \n Worship Service at 10:30am and 6:30pm\n \nWednesday: \n Bible Study and Prayer Meeting at 6:30pm \n Youth Service at 6:30pm \n";

        }

        /*void Handle_Activated(object sender, System.EventArgs e){

            if (FontButton.currentSize == 2)
            {
                FontButton.currentSize = 0;
            }
            else
            {
                FontButton.currentSize += 1;
            }

            fontSetting.Text = "Font: " + FontButton.textSize[FontButton.currentSize + 1].ToString();

            SetAboutTextSize();

            MessagingCenter.Send(Application.Current, "Hi");

        }*/

        /*void Handle_Activated(object sender, System.EventArgs e){

            FontButton.Handle_Activated();

            SetAboutSize();

        }*/

        void SetAboutSize(){

            AboutUsTitle.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

            AboutLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            FindUsLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

            AddressLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            ContactUsLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

            OfficeHoursTitle.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            OfficeHoursLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            NumberLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            TimesTitle.FontSize = Device.GetNamedSize(FontButton.GetTextSize(1), typeof(Label));

            TimesLabel.FontSize = Device.GetNamedSize(FontButton.GetTextSize(0), typeof(Label));

            switch(FontButton.GetTextSize(0)){

                case NamedSize.Micro: Pastor.HeightRequest = 125; break;

                case NamedSize.Small: Pastor.HeightRequest = 150; break;

                case NamedSize.Medium: Pastor.HeightRequest = 175; break;

                default: Pastor.HeightRequest = 150; break;

            }

        }

    }
}