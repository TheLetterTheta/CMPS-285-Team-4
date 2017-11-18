using System;

using Xamarin.Forms;

namespace JBC
{
    public class FontButton : ContentPage
    {
        static NamedSize[] textSize = { NamedSize.Micro, NamedSize.Small, NamedSize.Medium, NamedSize.Large };

        public static int currentSize = (Application.Current.Properties.ContainsKey("FontSize") ? Int32.Parse(Application.Current.Properties["FontSize"].ToString()) : 1);

        public FontButton(Page page){

            var fontSetting = new ToolbarItem
            {

                Icon = "fontSize.png",

                Text = "Font: " + textSize[currentSize + 1].ToString(),

                Order = ToolbarItemOrder.Primary,

                Command = new Command(Handle_Activated)

            };

            page.ToolbarItems.Add(fontSetting);

        }

        void Handle_Activated()
        {
            if (currentSize == 2)
            {
                currentSize = 0;
            }
            else
            {
                currentSize += 1;
            }

            MessagingCenter.Send(Application.Current, "Hi");

            Application.Current.Properties["FontSize"] = currentSize;
        }

        public static NamedSize GetTextSize(int offset)
        {
            if (currentSize + offset > 3 || currentSize + offset < 0)
                offset = 0;
            return textSize[currentSize + offset];
        }
    }
}

