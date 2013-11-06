using FirstFloor.ModernUI.Windows;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace MuiTest1.Content.ModernFrame
{
    /// <summary>
    /// Interaction logic for CancelNavigationContent.xaml
    /// </summary>
    public partial class CancelNavigationContent : UserControl, IContent
    {
        public CancelNavigationContent()
        {
            InitializeComponent();
        }

        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            fregmentNav.BBCode = string.Format(CultureInfo.CurrentUICulture, "Current navigation fragment: '[b]{0}[/b]'", e.Fragment);
        }

        public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            
        }

        public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            fregmentNav.BBCode = null;
        }

        public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            
        }
    }
}
