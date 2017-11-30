using Android.Webkit;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JBC.TabbedPages
{
    public partial class Notes_View : ContentPage
    {
        //public event EventHandler<PinchGestureUpdatedEventArgs> PinchUpdated;

        public Notes_View(System.Uri source)
        {
            InitializeComponent();

            fileView.Source = source;
            /*
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            fileView.GestureRecognizers.Add(panGesture);
            
            var pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += (s, e) => {
                // Handle the pinch
                //OnPinchUpdated;
            };
            fileView.GestureRecognizers.Add(pinchGesture);

            Content = new Grid
            {
                Padding = new Thickness(20),
                Children =
                {
                    new PinchToZoomContainer
                    {
                        Content = fileView,
                    }
                }
            };

        }
        
        void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
                // Handle the pinch

        }
        
        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var s = (ContentView)sender;

            // do not allow pan if the image is in its intial size
            if (currentScale == 1)
                return;

            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    double xTrans = xOffset + e.TotalX, yTrans = yOffset + e.TotalY;
                    // do not allow verical scorlling unless the image size is bigger than the screen
                    s.Content.TranslateTo(xTrans, yTrans, 0, Easing.Linear);
                    break;

                case GestureStatus.Completed:
                    // Store the translation applied during the pan
                    xOffset = s.Content.TranslationX;
                    yOffset = s.Content.TranslationY;

                    // center the image if the width of the image is smaller than the screen width
                    if (originalWidth * currentScale < ScreenWidth && ScreenWidth > ScreenHeight)
                        xOffset = (ScreenWidth - originalWidth * currentScale) / 2 - s.Content.X;
                    else
                        xOffset = System.Math.Max(System.Math.Min(0, xOffset), -System.Math.Abs(originalWidth * currentScale - ScreenWidth));

                    // center the image if the height of the image is smaller than the screen height
                    if (originalHeight * currentScale < ScreenHeight && ScreenHeight > ScreenWidth)
                        yOffset = (ScreenHeight - originalHeight * currentScale) / 2 - s.Content.Y;
                    else
                        //yOffset = System.Math.Max(System.Math.Min((originalHeight - (ScreenHeight)) / 2, yOffset), -System.Math.Abs((originalHeight * currentScale - ScreenHeight - (originalHeight - ScreenHeight) / 2)) + (NavBar.Height + App.StatusBarHeight));
                        yOffset = System.Math.Max(System.Math.Min((originalHeight - (ScreenHeight)) / 2, yOffset), -System.Math.Abs((originalHeight * currentScale - ScreenHeight - (originalHeight - ScreenHeight) / 2)));

                    // bounce the image back to inside the bounds
                    s.Content.TranslateTo(xOffset, yOffset, 500, Easing.BounceOut);
                    break;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called

            if (width != -1 && (ScreenWidth != width || ScreenHeight != height))
            {
                ResetLayout(width, height);

                originalWidth = initialLoad ?
                    ImageWidth >= 960 ?
                       App.ScreenWidth > 320
                            ? 768
                            : 320
                        : ImageWidth / 3
                    : imageContainer.Content.Width / imageContainer.Content.Scale;

                var normalizedHeight = ImageWidth >= 960 ?
                        App.ScreenWidth > 320 ? ImageHeight / (ImageWidth / 768)
                        : ImageHeight / (ImageWidth / 320)
                    : ImageHeight / 3;

                originalHeight = initialLoad ?
                    normalizedHeight : (imageContainer.Content.Height / imageContainer.Content.Scale);

                ScreenWidth = width;
                ScreenHeight = height;

                xOffset = imageContainer.TranslationX;
                yOffset = imageContainer.TranslationY;

                currentScale = imageContainer.Scale;

                if (initialLoad)
                    initialLoad = false;
            }
            */
        }
        
    }
}
