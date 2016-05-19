using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using Xamarin.Forms;
using XamarinFormsCameraSample.iOS;

[assembly: Dependency(typeof(CameraProvider))]
namespace XamarinFormsCameraSample.iOS
{
    public class CameraProvider : ICameraProvider
    {
        public Task<CameraResult> TakePictureAsync()
        {
            var tcs = new TaskCompletionSource<CameraResult>();

            Camera.TakePicture(UIApplication.SharedApplication.KeyWindow.RootViewController, (imagePickerResult) =>
            {

                if (imagePickerResult == null)
                {
                    tcs.TrySetResult(null);
                    return;
                }

                var photo = imagePickerResult.ValueForKey(new NSString("UIImagePickerControllerOriginalImage")) as UIImage;

                // You can get photo meta data with using the following
                // var meta = obj.ValueForKey(new NSString("UIImagePickerControllerMediaMetadata")) as NSDictionary;

                var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string jpgFilename = Path.Combine(documentsDirectory, Guid.NewGuid() + ".jpg");
                NSData imgData = photo.AsJPEG();
                NSError err = null;

                if (imgData.Save(jpgFilename, false, out err))
                {
                    CameraResult result = new CameraResult();
                    result.Image = ImageSource.FromStream(imgData.AsStream);
                    result.FileUri = jpgFilename;

                    tcs.TrySetResult(result);
                }
                else
                {
                    tcs.TrySetException(new Exception(err.LocalizedDescription));
                }
            });

            return tcs.Task;
        }
    }
}

