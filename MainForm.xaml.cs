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
        List<Phone> searchReq = new List<Phone>();
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

        private void RecycleBin_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Search_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchReq.Clear();
            Phones_ListBox.ItemsSource = phones;
            foreach (Phone phone in Phones_ListBox.Items)
            {
                if(phone.Models.ToLower().Contains(Search_TextBox.Text.ToLower()))
                {
                    searchReq.Add(phone);
                }
            }
            Phones_ListBox.ItemsSource = null;
            Phones_ListBox.Items.Clear();
            Phones_ListBox.ItemsSource = searchReq;
            if(Search_TextBox.Text.Length==0)
            {
                Phones_ListBox.ItemsSource = phones;
            }
        }
    }
}
