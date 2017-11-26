using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Facebook;
using Facebook;
using System.Collections.Generic;

namespace JBC.Droid
{
    [Activity(Label = "JBC.Droid", Icon = "@drawable/icon", Theme = "@style/splashscreen", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            base.Window.RequestFeature(WindowFeatures.ActionBar);
            // Name of the MainActivity theme you had there before.
            // Or you can use global::Android.Resource.Style.ThemeHoloLight
            base.SetTheme(Resource.Style.MyTheme);

            base.OnCreate(bundle);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //var token = new AccessToken($"119750732037000|8d7508c4f936eb4d70f1e198f194a21f", "119750732037000", "165257200173818", null, null, null, null, null);
            //var client = new FacebookClient($"119750732037000|8d7508c4f936eb4d70f1e198f194a21f");


            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);

            /* Facebhook API Stuff
            client.GetTaskAsync("me").ContinueWith(t => {
                if (!t.IsFaulted)
                {
                    var result = (IDictionary<string, object>)t.Result;
                    string myDetails = string.Format("Your name is: {0} {1} and your Facebook profile Url is: {3}",
                                                      (string)result["first_name"], (string)result["last_name"],
                                                      (string)result["link"]);
                    Console.WriteLine(myDetails);
                }
            });
            */


            LoadApplication(new App());


        }
    }
}
