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
            AboutLabel.Text = "\tAt Jerusalem Baptist Church, it’s our desire to be an open and welcoming place for community life and worship. We invite you to join us as we serve together for God’s glory. I believe that you’ll find Jerusalem Baptist Church to be a place where God is worshiped sincerely, Jesus Christ is preached triumphantly, His resurrection is celebrated joyously, the Gospel is shared unashamedly, and the Holy Spirit moves freely! I believe JBC is the place where you will find the help you need to overcome any physical obstacles, the healing to conquer any emotional hurts or struggles, and the hope to experience spiritual encouragement and a renewed purpose for living in Jesus Christ! Please join us for our weekly activities and special events. I’d love to share with you more about how you can become a part of the JBC family! I look forward to meeting you and pray God’s richest blessings upon you! \n\nIn Christ’s service, \n Dr. Phil Weaver, pastor";
            TimesLabel.Text = "Sunday:\n\t-Sunday School at 9:15am\n\t-Worship at 10:30am\n\t-Adult Bible Study & Prayer at 6:00pm\n\nWednesday:\n\t-Prayer Meeting at 6:30pm\n\t-Youth Service at 6:30pm";
        }
    }
}