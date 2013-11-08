using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuiTest1.Pages
{
    public class CustomCommandDisableCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return false;
        }
        protected override void OnExecute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
