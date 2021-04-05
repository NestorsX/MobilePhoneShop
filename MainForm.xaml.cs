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

        private void Phones_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Phone selectedPhone = (Phone)Phones_ListBox.SelectedItem;
            Phone_Image.Source = selectedPhone.getImage;
            PhoneModel_TextBlock.Text = "Модель: " + selectedPhone.Models + " " + selectedPhone.RamCapacity + "/" + selectedPhone.RomCapacity;
            PhoneOS_TextBlock.Text = "ОС: " + apc.os.Where(oss => oss.osID == selectedPhone.OsID).FirstOrDefault().Name;
            PhoneDisplay_TextBlock.Text = "Дисплей: " + apc.displayTeches.Where(display => display.displayTechID == selectedPhone.DisplayTechID).FirstOrDefault().Type;
            PhoneCameras_TextBlock.Text = "Камеры: основная: " + selectedPhone.MainCameraRes + " МП | фронтальная: " + selectedPhone.FrontCameraRes + " МП";
            PhoneAccumulator_TextBlock.Text = "Аккумулятор: " + apc.accs.Where(acc => acc.accID == selectedPhone.AccID).FirstOrDefault().Type + " " + selectedPhone.AccCapacity + " мАч";
            AddToBin_Button.Visibility = Visibility.Visible;
        }

        private void AddToBin_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
