using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ImageScale
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ctlImage_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {

        }

        private void ctlImage_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {

        }

        private void ctlImage_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {

        }

        private void ctlImage_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            double dbldelta_Scroll = e.GetCurrentPoint(ctlImage).Properties.MouseWheelDelta;  // getting the scroll position whether its up or down

            double posX = e.GetCurrentPoint(ctlImage).Position.X;      // getting the current points on which we will zoom the image
            double posY = e.GetCurrentPoint(ctlImage).Position.Y;      // getting the current points on which we will zoom the image
            double actualWidth = ctlImage.ActualWidth;   // pixel of real image
            double actualHEight = ctlImage.ActualHeight; // pixel of real image


            dbldelta_Scroll = (dbldelta_Scroll > 0) ? 1.1 : 0.9;        //if scroll was upwards, then increase it, else decrease
            double new_scaleX = this.image_Transform.ScaleX * dbldelta_Scroll;
            double new_scaleY = this.image_Transform.ScaleY * dbldelta_Scroll;

            double scale = 0.1;

            double new_translateX = (dbldelta_Scroll > 1) ? (this.image_Transform.TranslateX - (posX * scale * image_Transform.ScaleX))
                : (this.image_Transform.TranslateX - (posX * -scale * image_Transform.ScaleX));
            double new_translateY = (dbldelta_Scroll > 1) ? (this.image_Transform.TranslateY - (posY * scale * image_Transform.ScaleY))
                : (this.image_Transform.TranslateY - (posY * -scale * image_Transform.ScaleY));


            if (new_scaleX <= 1 | new_scaleY <= 1)
            {
                new_scaleX = 1;
                new_scaleY = 1;
                new_translateX = 0;
                new_translateY = 0;
            }


            image_Transform.ScaleX = new_scaleX;
            image_Transform.ScaleY = new_scaleY;
            image_Transform.TranslateX = new_translateX;
            image_Transform.TranslateY = new_translateY;
        }
    }
}
