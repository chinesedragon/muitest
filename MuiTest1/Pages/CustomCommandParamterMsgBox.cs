using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuiTest1.Pages
{
    public class CustomCommandParamterMsgBox : CommandBase
    {
        protected override void OnExecute(object parameter)
        {
            ModernDialog.ShowMessage(string.Format(CultureInfo.CurrentUICulture, "被超连接触发的带参数的对话框\r\n参数是:{0}", parameter),
                "带参数的对话框", System.Windows.MessageBoxButton.OK);
        }
    }
}
