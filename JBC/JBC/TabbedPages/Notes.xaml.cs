using System;
using System.Collections.Generic;

using Xamarin.Forms;

using JBC.TabbedPages;

namespace JBC
{
    public partial class Notes : ContentPage
    {
        public Notes()
        {
			InitializeComponent();

            //Lambda expression for handling navigating to a Notes page.
            directoryView.Navigated += (s, e) => {

                directoryView.Navigating += async (sender, eArg) => {

                    //eArg.Cancel = true;
                    //String searchUrlString = "http://jbcpc.org/sermon_notes/#search=";
                    //String filesUrlString = "http://jbcpc.org/sermon_notes/#files";
                    String ignoreUrl = "http://jbcpc.org/sermon_notes/#";
                    String requireUrl = "http://jbcpc.org/sermon_notes/files/";
                    //if (!(eArg.Url.StartsWith(searchUrlString)) && !(eArg.Url.StartsWith(filesUrlString)) && (eArg.Url != "http://jbcpc.org/sermon_notes/"))
                    if (!(eArg.Url.StartsWith(ignoreUrl)) && (eArg.Url.StartsWith(requireUrl)) && (eArg.Url != "http://jbcpc.org/sermon_notes/"))
                    {
                        
                        eArg.Cancel = true;
                        var uri = new Uri(eArg.Url);
                        await Navigation.PushAsync(new Notes_View(uri));

                    }

                };

            };
        }
    }
}
