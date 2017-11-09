using System;

using Xamarin.Forms;

namespace JBC
{
    public class FontButton : ContentPage
    {
        public static NamedSize[] textSize = { NamedSize.Micro, NamedSize.Small, NamedSize.Medium, NamedSize.Large };

        public static int currentSize = 1;

        public static void Handle_Activated()
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
        }

        public static NamedSize GetTextSize(int offset)
        {
            if (currentSize + offset > 3 || currentSize + offset < 0)
                offset = 0;
            return textSize[currentSize + offset];
        }
    }
}

