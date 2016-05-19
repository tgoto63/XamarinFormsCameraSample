using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace XamarinFormsCameraSample
{
    public partial class CameraTestView : ContentPage
    {
        public CameraTestView()
        {
            InitializeComponent();

            this.CameraButton.Clicked += OnAlertYesNoClicked;
        }

        async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            var cameraProvider = DependencyService.Get<ICameraProvider>();
            //Debug.WriteLine(cameraProvider);
            var photoResult = await cameraProvider.TakePictureAsync();

            //var answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
        }

        //public ICommand TakePicture { get; set; }

        //private ICameraProvider cameraProvider;

        //public TakePictureViewModel(ICameraProvider cameraProvider)
        //{
        //    if (cameraProvider == null)
        //    {
        //        throw new ArgumentNullException("cameraProvider");
        //    }

        //    TakePicture = new Command(async () => await TakePictureAsync());
        //    this.cameraProvider = cameraProvider;
        //}

        //private async Task TakePictureAsync()
        //{

        //    if (photoResult != null)
        //    {
        //        Picture = photoResult.Picture;
        //    }
        //}
    }
}

