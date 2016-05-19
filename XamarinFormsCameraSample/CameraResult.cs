using System;
using Xamarin.Forms;

namespace XamarinFormsCameraSample
{
    public class CameraResult
    {
        // For displaying the picture on a page
        public ImageSource Image { get; set; }

        // Location on the device where the taken picture is stored
        public string FileUri { get; set; }
    }
}

