using FirstFloor.ModernUI.Presentation;
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
    /// Interaction logic for ModernMenuControl.xaml
    /// </summary>
    public partial class ModernMenuControl : UserControl
    {
        private int groupID = 2;
        private int linkID = 5;

        public ModernMenuControl()
        {
            InitializeComponent();

            this.addGroup.Command = new RelayCommand( o => {
                this.Menu.LinkGroups.Add(new LinkGroup()
                    {
                        DisplayName = string.Format(CultureInfo.CurrentUICulture, "Group {0}", ++groupID),
                    });
            });

            this.addLink.Command = new RelayCommand(o =>
                {
                    this.Menu.SelectedLinkGroup.Links.Add(new Link()
                        {
                            DisplayName = string.Format(CultureInfo.CurrentUICulture, "Link {0}", ++linkID),
                            Source = new Uri(string.Format(CultureInfo.CurrentUICulture, "/Link{0}", linkID), UriKind.Relative),
                        });
                }, o => this.Menu.SelectedLinkGroup != null);

            this.removeGroup.Command = new RelayCommand(o =>
            {
                this.Menu.LinkGroups.Remove(this.Menu.SelectedLinkGroup);
            }, o => this.Menu.SelectedLinkGroup != null);

            this.removeLink.Command = new RelayCommand(o =>
            { this.Menu.SelectedLinkGroup.Links.Remove(this.Menu.SelectedLink); },
            o => this.Menu.SelectedLinkGroup != null && this.Menu.SelectedLink != null);
        }
    }
}
