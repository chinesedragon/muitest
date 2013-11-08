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

namespace MuiTest1.Content
{
    /// <summary>
    /// Interaction logic for ModernFrameControl.xaml
    /// </summary>
    public partial class ModernFrameControl : UserControl
    {
        private string eventLogMsg;

        public ModernFrameControl()
        {
            InitializeComponent();

            this.TextEvents.Text = eventLogMsg;
        }

        private void LogMessage(string message, params object[] o)
        {
            message = string.Format(CultureInfo.CurrentUICulture, message, o);

            if (this.TextEvents == null)
            {
                this.eventLogMsg += message;
            }
            else
            {
                this.TextEvents.AppendText(message);
            }
        }
        private void Frame_FragmentNavigation(object sender, FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            LogMessage("FragmentNavigation: {0}\r\n", e.Fragment);
        }

        private void Frame_Navigated(object sender, FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            LogMessage("Navigated: [{0}] {1}\r\n", e.NavigationType, e.Source);
        }

        private void Frame_Navigating(object sender, FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            LogMessage("Navigating: [{0}] {1}\r\n", e.NavigationType, e.Source);
        }

        private void Frame_NavigationFailed(object sender, FirstFloor.ModernUI.Windows.Navigation.NavigationFailedEventArgs e)
        {
            LogMessage("NavigationFailed: {0}\r\n", e.Error.Message);
        }
    }
}
