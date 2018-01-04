using PCLStorage;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopicDetalPage : TabbedPage
    {
        //private string path = "";

        private string videoUrl = "https://sec.ch9.ms/ch9/cbbe/615f48d6-12ac-45a1-8a4f-356f2318cbbe/azuregovtechnicalcommunity_high.mp4";
        public TopicDetalPage()
        {
            InitializeComponent();
            //var file = DoWork("http://codedenim.azurewebsites.net/MaterialUpload/C1_Module%201.pdf");
            this.BindingContext = new
            {
                PdfUrl = "http://codedenim.azurewebsites.net/MaterialUpload/C1_Module%201.pdf",
            };
        }

        //pdfBrower.Source = "http://www.lequydonhanoi.edu.vn/upload_images/S%C3%A1ch%20ngo%E1%BA%A1i%20ng%E1%BB%AF/Rich%20Dad%20Poor%20Dad.pdf";


        public async Task DoWork(string url)
        {
            var filesStream = await DownloadFile(url);
            var filepath = await SaveFileAsync("First.pdf", filesStream);
            //var path = await GetFileStreamAsync("");

            //path = filepath;
        }

        public async Task<MemoryStream> DownloadFile(string url)
        {
            var stream = new MemoryStream();
            using (var httpClient = new HttpClient())
            {
                var downloadStream = await httpClient.GetStreamAsync(new Uri(url));
                if (downloadStream != null)
                {
                    await downloadStream.CopyToAsync(stream);
                }
            }
            return stream;
        }

        public static async Task<string> SaveFileAsync(string fileName, MemoryStream inputStream)
        {
            var file = await FileSystem.Current.LocalStorage.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            using (var stream = await file.OpenAsync(PCLStorage.FileAccess.ReadAndWrite))
            {
                inputStream.WriteTo(stream);
            }
            return file.Path;
        }
        public static async Task<Stream> GetFileStreamAsync(string filePath)
        {
            var openAsync = (await FileSystem.Current.GetFileFromPathAsync(filePath))?.OpenAsync(PCLStorage.FileAccess.Read);
            if (openAsync == null)
            {
                return null;
            }
            return await openAsync;
        }
        private void WebOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            // loading.IsVisible = false;
        }

        private void WebOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            // loading.IsVisible = true;
        }

        //private void PlayStopClicked(object sender, EventArgs e)
        //{
        //    if (PlayStopButton.Text.Equals("Play"))
        //    {
        //        CrossMediaManager.Current.Play(videoUrl, MediaFileType.Video);
        //        PlayStopButton.Text = "Stop";

        //    }
        //    else if (PlayStopButton.Text.Equals("Stop"))
        //    {
        //        CrossMediaManager.Current.Stop();
        //        PlayStopButton.Text = "Play";

        //    }

        //}
    }
}