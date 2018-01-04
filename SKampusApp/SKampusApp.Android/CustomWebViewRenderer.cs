using Android.Content;
using SKampusApp.Droid;
using System.Net;
using SKampusApp;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace SKampusApp.Droid
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        public CustomWebViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var customWebView = Element as CustomWebView;
                //Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.Settings.AllowContentAccess = true;
                var ecodedUrl = WebUtility.UrlEncode(customWebView.Uri);

                //Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///android_asset/Content/{0}", WebUtility.UrlEncode(customWebView.Uri))));
                Control.LoadUrl("file:///android_asset/pdfjs/web/viewer.html?file=" + ecodedUrl);
                //http://codedenim.azurewebsites.net/MaterialUpload/C1_Module%201.pdf
                //Control.LoadUrl(WebUtility.UrlEncode(customWebView.Uri));

            }
        }
    }
}