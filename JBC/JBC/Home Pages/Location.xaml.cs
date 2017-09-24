using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace JBC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Location : ContentPage
    {
        public Location()
        {
            InitializeComponent();

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                        new Position(30.45150099999997, -90.5389680000001),
                        Distance.FromMiles(0.25)));

			// Latitude, Longitude of the church
			var church = new Position(30.45150099999997, -90.5389680000001);

            //Add pin at the church's latitude and longitude
			var pin = new Pin
			{
				Type = PinType.Place,
				Position = church,
				Label = "Jerusalem Baptist Church",
				Address = "11109 Jerusalem Baptist Church Rd. Hammond, LA 70403"
			};

			pin.Clicked += (sender, args) => {

                if (Device.RuntimePlatform == Device.iOS)
				{
					// opens Apple Maps app directly
					Device.OpenUri(new Uri("http://maps.apple.com/?q=11109+Jerusalem+Church+Rd.+Hammond,+LA+70403"));
				}
                else if (Device.RuntimePlatform == Device.Android)
				{
					// opens Google Maps app directly
					Device.OpenUri(new Uri("geo:0,0?q=11109+Jerusalem+Church+Rd.+Hammond,+LA+70403"));

				}

			};

			MyMap.Pins.Add(pin);
        }

        //async void Location_Clicked(object sender, EventArgs e)
       // {
        //    await Navigation.PopAsync();
        //}



    }
}