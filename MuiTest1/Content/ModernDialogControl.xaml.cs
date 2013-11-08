using FirstFloor.ModernUI.Windows.Controls;
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

namespace MuiTest1.Content
{
    /// <summary>
    /// Interaction logic for ModernDialogControl.xaml
    /// </summary>
    public partial class ModernDialogControl : UserControl
    {
        public ModernDialogControl()
        {
            InitializeComponent();
        }

        private void CommonDialog_Clicked(object sender, RoutedEventArgs e)
        {
            new ModernDialog
            {
                Title = "Common Dialog",
                Content = "hello \nworld"
            }.ShowDialog();
        }

        private void MessageDialog_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OK;
            if (ok.IsChecked == true)
            {
                btn = MessageBoxButton.OK;
            }
            else if (okcancel.IsChecked == true)
            {
                btn = MessageBoxButton.OKCancel;
            }
            else if (yesno.IsChecked == true)
            {
                btn = MessageBoxButton.YesNo;
            }
            else
            {
                btn = MessageBoxButton.YesNoCancel;
            }

            var result = ModernDialog.ShowMessage("this is the message.", "modern message", btn);

            runresult.Text = result.ToString();
        }
    }
}
