using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuiTest1.Pages
{
    /// <summary>
    /// Interaction logic for ContentLoader.xaml
    /// </summary>
    public partial class ContentLoader : UserControl
    {
        public ContentLoader()
        {
            InitializeComponent();

            LoadImageLinks();
        }

        private async void LoadImageLinks()
        {
            FlickrImageLoader loader = (FlickrImageLoader)Tab.ContentLoader;

            this.Tab.Links = await loader.GetInterestingImageListAsync();

            this.Tab.SelectedSource = this.Tab.Links.Select(l => l.Source).FirstOrDefault();
        }
    }
}
