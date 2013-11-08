using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MuiTest1.assets
{
    public static class BingImage
    {
        private static BitmapImage cacheBingImage;

        public static bool GetUseBingImage(DependencyObject obj)
        {
            return (bool)obj.GetValue(UseBingImageProperty);
        }

        public static void SetUseBingImage(DependencyObject obj, bool value)
        {
            obj.SetValue(UseBingImageProperty, value);
        }

        // Using a DependencyProperty as the backing store for UseBingImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UseBingImageProperty =
            DependencyProperty.RegisterAttached("UseBingImage", typeof(bool), typeof(BingImage), new PropertyMetadata(OnUseBingImageChanged));

        private static async void OnUseBingImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newValue = (bool)e.NewValue;
            var image = d as Image;
            var imageBrush = d as ImageBrush;

            if (!newValue || (image == null && imageBrush == null))
            {
                return;
            }

            if (cacheBingImage == null)
            {
                var url = await GetCurrentBingImageUrl();
                if (url != null)
                {
                    cacheBingImage = new BitmapImage(url);
                }
            }

            if (cacheBingImage != null)
            {
                if (image != null)
                {
                    image.Source = cacheBingImage;
                }
                if (imageBrush != null)
                {
                    imageBrush.ImageSource = cacheBingImage;
                }
            }
        }

        private static async Task<Uri> GetCurrentBingImageUrl()
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://cn.bing.com/hpimagearchive.aspx?format=xml&idx=0&n=2&mbl=1&mkt=zh-ww");
            if (result.IsSuccessStatusCode)
            {
                using (var stream = await result.Content.ReadAsStreamAsync())
                {
                    var doc = XDocument.Load(stream);

                    string url = (string)doc.XPathSelectElement("/images/image/url");

                    return new Uri(string.Format(CultureInfo.CurrentUICulture, "http://bing.com{0}", url), UriKind.Absolute);
                }
            }
            return null;
        }
    }
}
