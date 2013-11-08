using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuiTest1.Pages
{
    public class CustomCommandMsgBox : CommandBase
    {
        protected override void OnExecute(object parameter)
        {
            ModernDialog.ShowMessage("被超连接触发的对话框", "对话框", System.Windows.MessageBoxButton.OK);
        }
    }
}
