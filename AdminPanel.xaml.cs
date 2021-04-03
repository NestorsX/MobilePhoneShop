using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class AdminPanel : Window
    {
        AccessToDB acdb = new AccessToDB();
        AppContext apc = new AppContext();
        List<Phone> phones;
        public AdminPanel()
        {
            InitializeComponent();
            OS_ComboBox.ItemsSource = apc.os.ToList();
            DisplayTech_ComboBox.ItemsSource = apc.displayTeches.ToList();
            Accum_ComboBox.ItemsSource = apc.accs.ToList();
            Users_ListBox.ItemsSource = apc.phones.ToList();
            phones = apc.phones.ToList();
        }

        private void AddMobilePhone_Click(object sender, RoutedEventArgs e)
        {
            string osID = OS_ComboBox.SelectedIndex.ToString();
            string displayTechID = DisplayTech_ComboBox.SelectedIndex.ToString();
            string model = Model_TextBox.Text;
            string simCount = SimCount_TextBox.Text;
            string processor = Processor_TextBox.Text;
            string mainCamRes = MainCameraRes_TextBox.Text;
            string frontCamRes = FrontCameraRes_TextBox.Text;
            string ramCapacity = RAMCapacity_TextBox.Text;
            string romCapacity = ROMCapacity_TextBox.Text;
            string colour = Colour_TextBox.Text;
            string weight = Weight_TextBox.Text;
            string accumID = Accum_ComboBox.SelectedIndex.ToString();
            string cost = Cost_TextBox.Text;
            if(Convert.ToInt32(osID)>-1 && Convert.ToInt32(displayTechID)>-1 && model.Length>0 && simCount.Length>0 && processor.Length>0 && mainCamRes.Length>0 
                && frontCamRes.Length>0 && ramCapacity.Length>0 && romCapacity.Length>0 && colour.Length>0 && weight.Length>0 && Convert.ToInt32(accumID)>-1 
                && Convert.ToDouble(cost)>0)
            {
                acdb.Insert($"INSERT INTO [phones] VALUES({osID+1}, {displayTechID+1}, '{model}', {simCount}, " +
                    $"'{processor}', {mainCamRes}, {frontCamRes}, {ramCapacity}, {romCapacity}, '{colour}', {weight}, {accumID+1}, {cost})");
                MessageBox.Show("Телефон добавлен в систему");
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                Close();
            }
        }

        private void AddOS_Click(object sender, RoutedEventArgs e)
        {
            string OS = OsType_TextBox.Text;
            if(OS.Length>0)
            {
                acdb.Insert($"INSERT INTO [os] VALUES({OS})");
                MessageBox.Show("ОС добавлена");
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                Close();
            }
        }

        private void AddDisplay_Click(object sender, RoutedEventArgs e)
        {
            string display = Display_TextBox.Text;
            if (display.Length > 0)
            {
                acdb.Insert($"INSERT INTO [displayTeches] VALUES({display})");
                MessageBox.Show("Тип матрицы добавлен");
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                Close();
            }
        }

        private void AddAccumulator_Click(object sender, RoutedEventArgs e)
        {
            string accum = Accumulator_TextBox.Text;
            if (accum.Length > 0)
            {
                acdb.Insert($"INSERT INTO [accs] VALUES({accum})");
                MessageBox.Show("Тип аккумулятора добавлен");
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                Close();
            }
        }

        private void DeletePhone_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
