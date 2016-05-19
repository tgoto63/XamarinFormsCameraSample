using System;
using System.Threading.Tasks;

namespace XamarinFormsCameraSample
{
    public interface ICameraProvider
    {
        Task<CameraResult> TakePictureAsync();
    }
}

