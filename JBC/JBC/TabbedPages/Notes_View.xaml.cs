using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JBC.TabbedPages
{
    public partial class Notes_View : ContentPage
    {
        public Notes_View(System.Uri source)
        {
            InitializeComponent();

            fileView.Source = source;
        }
    }
}
