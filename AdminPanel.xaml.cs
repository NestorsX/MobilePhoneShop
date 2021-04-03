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
    public partial class AdminPanel : Window
    {
        AccessToDB acdb = new AccessToDB();
        AppContext apc = new AppContext();
        public AdminPanel()
        {
            InitializeComponent();
            OS_ComboBox.ItemsSource = apc.os.ToList();
            DisplayTech_ComboBox.ItemsSource = apc.displayTeches.ToList();
            Accum_ComboBox.ItemsSource = apc.accs.ToList();
        }

        private void AddMobilePhone_Click(object sender, RoutedEventArgs e)
        {
            string osID = OS_ComboBox.SelectedIndex.ToString();
            string displayTechID = DisplayTech_ComboBox.SelectedIndex.ToString();
            string model = Model_TextBox.Text;
            string simCount = Model_TextBox.Text;
            string processor = Processor_TextBox.Text;
            string mainCamRes = MainCameraRes_TextBox.Text;
            string frontCamRes = FrontCameraRes_TextBox.Text;
            string ramCapacity = RAMCapacity_TextBox.Text;
            string romCapacity = ROMCapacity_TextBox.Text;
            string colour = Colour_TextBox.Text;
            string weight = Weight_TextBox.Text;
            string accumID = Accum_ComboBox.SelectedIndex.ToString();
            string cost = Cost_TextBox.Text;
            if(Convert.ToInt32(osID)>-1 && Convert.ToInt32(displayTechID)>0 && model.Length>0 && simCount.Length>0 && processor.Length>0 && mainCamRes.Length>0 
                && frontCamRes.Length>0 && ramCapacity.Length>0 && romCapacity.Length>0 && colour.Length>0 && weight.Length>0 && Convert.ToInt32(accumID)>-1 
                && Convert.ToDouble(cost)>0)
            {
                acdb.Insert($"INSERT INTO [phones] SELECT({osID}, {displayTechID}, '{model}', {simCount}, '{processor}', {mainCamRes}, {frontCamRes}, " +
                    $"{ramCapacity}, {romCapacity}, '{colour}', {weight}, {accumID}, {cost})");
            }
        }
    }
}
