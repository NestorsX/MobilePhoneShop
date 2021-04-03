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
using System.Windows.Shapes;

namespace MobilePhoneShop
{
    public partial class MainForm : Window
    {
        AccessToDB acdb = new AccessToDB();
        AppContext apc = new AppContext();
        List<Phone> phones;
        public MainForm()
        {
            InitializeComponent();
            phones = apc.phones.ToList();
            Phones_ListBox.ItemsSource = phones;
        }

        private void Profile_Button_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow pfw = new ProfileWindow();
            pfw.Owner = this;
            Hide();
            pfw.ShowDialog();
        }
    }
}
