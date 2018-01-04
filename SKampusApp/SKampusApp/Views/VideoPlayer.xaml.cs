using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPlayer : ContentPage
    {
        private string videoUrl = "https://sec.ch9.ms/ch9/cbbe/615f48d6-12ac-45a1-8a4f-356f2318cbbe/azuregovtechnicalcommunity_high.mp4";

        public VideoPlayer()
        {
            InitializeComponent();
        }

        //private void PlayStopClicked(object sender, EventArgs e)
        //{
        //    if (PlayStopButton.Text == "Play")
        //    {
        //        CrossMediaManager.Current.Play(videoUrl, MediaFileType.Video);
        //        PlayStopButton.Text = "Stop";

        //    }
        //    else if (PlayStopButton.Text == "Stop")
        //    {
        //        CrossMediaManager.Current.Stop();
        //        PlayStopButton.Text = "Play";

        //    }
        //}
    }
}