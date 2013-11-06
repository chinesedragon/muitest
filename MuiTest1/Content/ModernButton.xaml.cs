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
using System.Xml.Linq;

namespace MuiTest1.Content
{
    /// <summary>
    /// Interaction logic for ModernButton.xaml
    /// </summary>
    public partial class ModernButton : UserControl
    {
        public ModernButton()
        {
            InitializeComponent();

            //找到全部嵌入的xaml icon文件
            var assembly = GetType().Assembly;
            var iconResourceNames = from name in assembly.GetManifestResourceNames()
                                    where name.StartsWith("MuiTest1.assets.appbar.")
                                    select name;

            foreach (var name in iconResourceNames)
            {
                using (var stream = assembly.GetManifestResourceStream(name))
                {
                    var doc = XDocument.Load(stream);

                    var path = doc.Root.Element("{http://schemas.microsoft.com/winfx/2006/xaml/presentation}Path");
                    if (path != null)
                    {
                        var data = (string)path.Attribute("Data");

                        ButtonPanel.Children.Add(new FirstFloor.ModernUI.Windows.Controls.ModernButton
                            {
                                IconData = PathGeometry.Parse(data),
                                Margin = new Thickness(0, 0, 0, 8)
                            });
                    }
                }
            }
        }
    }
}
