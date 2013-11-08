using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace MuiTest1.Pages
{
    public class FlickrImageLoader : IContentLoader
    {
        private const string apiKey = "313dde775666d6231e90c21ec6023399";           // your flickr API key here
        public async Task<LinkCollection> GetInterestingImageListAsync()
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("Flickr API key不存在或者已经过期了。\r\n可以从http://www.flickr.com/services/api/misc.api_keys.html申请。");
            }
            const int count = 50;
            var listurl = string.Format(CultureInfo.InvariantCulture, "http://api.flickr.com/services/rest/?method=flickr.interestingness.getList&api_key={0}&per_page={1}", apiKey, count);
            var client = new HttpClient();
            var result = await client.GetAsync(listurl);
            using (var stream = await result.Content.ReadAsStreamAsync())
            {
                var doc = XDocument.Load(stream);

                return new LinkCollection(from p in doc.Descendants("photo")
                                            let title = (string)p.Attribute("title")
                                            orderby title
                                            select new Link
                                            {
                                                DisplayName = string.IsNullOrWhiteSpace(title) ? "[untitled]" : title,
                                                Source = new Uri(string.Format(CultureInfo.InvariantCulture, "http://farm{0}.static.flickr.com/{1}/{2}_{3}.jpg", (string)p.Attribute("farm"), (string)p.Attribute("server"), (string)p.Attribute("id"), (string)p.Attribute("secret")), UriKind.Absolute)
                                            });
            }
        }
        public async Task<object> LoadContentAsync(Uri uri, System.Threading.CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var result = await client.GetAsync(uri, cancellationToken);

            result.EnsureSuccessStatusCode();

            using (var stream = await result.Content.ReadAsStreamAsync())
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();

                return new Image { Source = bitmap };
            }
        }
    }
}
